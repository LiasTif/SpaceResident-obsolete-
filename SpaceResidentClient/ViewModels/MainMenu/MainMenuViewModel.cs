using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Services;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal partial class MainMenuViewModel : ObservableObject
    {
        #region props
        [ObservableProperty]
        public ObservableObject? currentUCViewModel;

        [ObservableProperty]
        public string consoleText = String.Empty;

        [ObservableProperty]
        public Visibility isContentControlBackgoundVisible = Visibility.Collapsed;
        #endregion

        #region commands
        public ICommand ShutdownCommand { get; }
        public ICommand SettingsViewSwitchCommand { get; }

        private void Shutdown() => App.Current.Shutdown();
        public void SettingsViewSwitch()
        {
            // open settings view if it`s already opened, close if opened
            if (CurrentUCViewModel is SettingsViewModel)
            {
                CurrentUCViewModel = null;
                IsContentControlBackgoundVisible = Visibility.Collapsed;
            }
            else
            {
                CurrentUCViewModel = new SettingsViewModel(this);
                IsContentControlBackgoundVisible = Visibility.Visible;
            }
        }
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
            SettingsViewSwitchCommand = new RelayCommand(SettingsViewSwitch);

            ConsoleTimerAsync();
        }
    }
}