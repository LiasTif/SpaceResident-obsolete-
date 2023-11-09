using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Services;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal partial class MainMenuViewModel : ObservableObject
    {
        #region props
        [ObservableProperty]
        public ObservableObject? currentUCViewModel;

        [ObservableProperty]
        public string consoleText;
        #endregion

        #region commands
        private void Shutdown() => App.Current.Shutdown();
        private void OpenSettings() => CurrentUCViewModel = new SettingsViewModel(this);
        public ICommand ShutdownCommand { get; }
        public ICommand OpenSettingsCommand { get; }
        #endregion

        #region animations
        // Console download animation timer
        private async Task ConsoleTimerAsync()
        {
            // run async metod ConsoleTypewriteAsync in another thread
            await Task.Run(ConsoleTypewriteAsync);

            // Decorative download animation in console
            Timer timer = new(100)
            {
                AutoReset = true,
                Enabled = true
            };
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        // Console typewrite animation thread
        private async Task ConsoleTypewriteAsync()
        {
            string consoleMessage = $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 |";
            

            // typewrite the text in console
            for (int i = 0; i < consoleMessage.Length; i++)
            {
                ConsoleText += consoleMessage[i];
                
                await Task.Delay(30);
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            int lastLetterIndex = ConsoleText.Length - 1;

            if (ConsoleText[^1] == '/')
                ConsoleText = ConsoleText.Remove(lastLetterIndex, 1) + "\\";
            else if (ConsoleText[^1] == '|')
                ConsoleText = ConsoleText.Remove(lastLetterIndex, 1) + "/";
            else
                ConsoleText = ConsoleText.Remove(lastLetterIndex, 1) + "|";
        }
        #endregion

        public MainMenuViewModel(NavigationStore navigationStore)
        {
            ShutdownCommand = new RelayCommand(Shutdown);
            OpenSettingsCommand = new RelayCommand(OpenSettings);

            ConsoleTimerAsync();
        }
    }
}