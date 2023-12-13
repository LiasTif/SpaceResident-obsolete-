using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.Windows;
using SpaceResidentClient.Views.Windows;
using System.Threading;
using System.Windows;

namespace SpaceResidentClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var langCode = SpaceResidentClient.Properties.Settings.Default.languageCode;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);

            MainWindow mainWindow = new();
            MainWindowViewModel mainWindowVM = new(new NavigationStore());

            mainWindow.DataContext = mainWindowVM;
            mainWindow.Show();
        }
    }
}
