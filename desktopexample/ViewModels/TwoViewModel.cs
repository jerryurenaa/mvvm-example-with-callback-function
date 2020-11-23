using desktopexample.Core;
using System;
using System.Windows.Input;

namespace desktopexample.ViewModels
{
    public class TwoViewModel : Router
    {
        public TwoViewModel() 
        {
            Console.WriteLine("mmg");
        }

        public ICommand GoTo1
        {
            get
            {
                return new RelayCommand(x => SwitchView("OneViewModel"));
            }
        }
    }
}
