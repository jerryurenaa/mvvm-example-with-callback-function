using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace desktopexample.Core
{
    public class Router : BaseViewModel
    {
        private static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        private static List<Action<string>> callback = new List<Action<string>>();

        private static string _currentViewModel = "OneViewModel";//Default view


        //Constructor
        public Router() 
        {
            string nameSpace = Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            foreach(Type type in types) 
            {
                if(type.Namespace == $"{nameSpace}.ViewModels" && type.Name != "<>c") 
                {
                    if (!dictionary.ContainsKey(type.Name)) 
                    {
                        dictionary.Add(type.Name, type.FullName);
                    }
                }
            }

            callback.Add(HandleSwitch);
        }


        public Router CurrentView
        {
            get
            {
                return (Router)Activator.CreateInstance(Type.GetType(dictionary[_currentViewModel]));
            }
            set
            {
                CurrentView = value;

                OnPropertyChanged("CurrentView");
            }
        }


        void HandleSwitch(string viewName) 
        {
            _currentViewModel = viewName;

            OnPropertyChanged("CurrentView");
        }


        public static void SwitchView(string viewName)
        {
            if (dictionary.ContainsKey(viewName))
            {
                callback[0](viewName);

                return;
            }

            Console.WriteLine($"Invalid ViewModel name: {viewName}");
        }
    }

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
