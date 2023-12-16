using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.ViewModels.CharacterCreation;
using SpaceResidentClient.ViewModels.Windows;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    partial class MainMenuViewModel : ObservableObject
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        #region props
        [ObservableProperty]
        public ObservableObject? currentUCViewModel;

        [ObservableProperty]
        public string consoleText = string.Empty;
        #endregion

        #region commands
        public ICommand ShutdownCommand { get; }
        public ICommand SettingsViewSwitchCommand { get; }
        public ICommand OpenCharacterCreationCommand { get; }

        private void OpenCharacterCreation() => _mainWindowViewModel.NavigationStore.CurrentViewModel =
            new CharacterCreationViewModel(_mainWindowViewModel, _mainWindowViewModel.NavigationStore);

        private void Shutdown() => App.Current.Shutdown();
        public void SettingsViewSwitch()
        {
            // open settings view if it`s already opened, close if opened
            CurrentUCViewModel = CurrentUCViewModel is SettingsViewModel ? null :
                new SettingsViewModel(this, _mainWindowViewModel);
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
            foreach (char symbol in consoleMessage)
            {
                ConsoleText += symbol;
                
                await Task.Delay(30);
            }
        }

        private void OnTimedEvent(Object? source, ElapsedEventArgs e)
        {
            switch (ConsoleText[^1])
            {
                case '/':
                    ReplaceLastSymbolInConsoleText("\\");
                    break;
                case '|':
                    ReplaceLastSymbolInConsoleText("/");
                    break;
                default:
                    ReplaceLastSymbolInConsoleText("|");
                    break;
            }
        }

        private void ReplaceLastSymbolInConsoleText(string symbol)
        {
            ConsoleText = ConsoleText.Remove(ConsoleText.Length - 1, 1) + symbol;
        }
        #endregion

        public MainMenuViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            ShutdownCommand = new RelayCommand(Shutdown);
            SettingsViewSwitchCommand = new RelayCommand(SettingsViewSwitch);
            OpenCharacterCreationCommand = new RelayCommand(OpenCharacterCreation);

            #pragma warning disable 4014
            ConsoleTimerAsync();
            #pragma warning restore 4014
        }
    }
}