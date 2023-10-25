using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.API;
using System;
using System.Threading.Tasks;
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
                    SetProperty(ref _consoleText, value);
            }
        }

        #region commands
        private void Shutdown() => App.Current.Shutdown();
        public ICommand ShutdownCommand { get; }
        #endregion

        public MainMenuViewModel(NavigationStore navigationStore)
        {
            ShutdownCommand = new RelayCommand(Shutdown);

            ConsoleTimerAsync();
        }

        #region Animations
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
    }
}