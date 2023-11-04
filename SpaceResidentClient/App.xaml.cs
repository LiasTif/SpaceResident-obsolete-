using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.Windows;
using SpaceResidentClient.Views.Windows;
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
            MainWindow mainWindow = new();
            MainWindowViewModel mainWindowVM = new(new NavigationStore());

            mainWindow.DataContext = mainWindowVM;
            mainWindow.Show();
        }
    }
}
