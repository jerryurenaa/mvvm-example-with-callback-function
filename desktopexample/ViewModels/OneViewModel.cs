using desktopexample.Core;
using System;
using System.Windows.Input;

namespace desktopexample.ViewModels
{
    public class OneViewModel : Router
    {
        public OneViewModel()
        {
            Console.WriteLine("mmg");
        }

        public ICommand GoTo2
        {
            get
            {
                return new RelayCommand(x => SwitchView("TwoViewModel"));
            }
        }
    }
}
