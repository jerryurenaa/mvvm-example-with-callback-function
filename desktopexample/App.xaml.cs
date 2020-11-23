using desktopexample.Core;
using System.Windows;

namespace desktopexample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow app = new MainWindow();

            Router context = new Router();

            app.DataContext = context;

            app.Show();
        }
    }
}
