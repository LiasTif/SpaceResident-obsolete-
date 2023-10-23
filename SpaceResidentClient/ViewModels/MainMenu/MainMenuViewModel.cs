using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.API;
using System;
using System.Timers;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal class MainMenuViewModel : ObservableObject
    {
        private string _consoleText;
        public string ConsoleText
        {
            get => _consoleText;
            set
            {
                if (value != _consoleText)
                {
                    _consoleText = value;
                    OnPropertyChanged(nameof(ConsoleText));
                }
            }
        }

        #region commands
        private void Shutdown() => App.Current.Shutdown();
        public ICommand ShutdownCommand { get; }
        #endregion

        public MainMenuViewModel(NavigationStore navigationStore)
        {
            ShutdownCommand = new RelayCommand(Shutdown);

            ConsoleText = $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 |";
            MyTimer();
        }

        private void MyTimer()
        {
            Timer timer = new(100);
            timer.Elapsed += HandleTimer;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void HandleTimer(Object source, ElapsedEventArgs e)
        {
            if (ConsoleText == $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 /")
                ConsoleText = $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 \\";
            else if (ConsoleText == $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 |")
                ConsoleText = $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 /";
            else
                ConsoleText = $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 |";
        }
    }
}