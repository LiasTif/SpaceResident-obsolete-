using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.CharacterCreation;
using SpaceResidentClient.ViewModels.Windows.Interfaces;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    partial class MainMenuViewModel : ObservableObject
    {
        private readonly IWindowNavigationStore _windowViewModel;
        private readonly IWindowScreenMode _windowScreenMode;

        public MainMenuViewModel(IWindowNavigationStore windowViewModel, IWindowScreenMode windowScreenMode)
        {
            _windowViewModel = windowViewModel;
            _windowScreenMode = windowScreenMode;

            ShutdownCommand = new RelayCommand(Shutdown);
            SettingsViewSwitchCommand = new RelayCommand(SettingsViewSwitch);
            OpenCharacterCreationCommand = new RelayCommand(OpenCharacterCreation);

            ConsoleTimerAsync();
        }

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
        #endregion

        #region methods
        private void Shutdown() => App.Current.Shutdown();
        private void OpenCharacterCreation()
        {
            CharacterCreationTabsBuffer b = new();
            _windowViewModel.NavigationStore.CurrentViewModel = b.InitializeCharacterCreationVM(_windowViewModel, _windowScreenMode);
        }
        public void SettingsViewSwitch()
        {
            // open settings view if it`s already opened, close if opened
            CurrentUCViewModel = CurrentUCViewModel is SettingsViewModel ? null :
                new SettingsViewModel(this, _windowScreenMode);
        }

        #region animations
        // Console download animation timer
        private async void ConsoleTimerAsync()
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
            string consoleText = $"command: install AllOrganicDB -force\nisntalling: AllOrganicDB package1 |";

            // typewrite the text in console
            foreach (char c in consoleText)
            {
                ConsoleText += c;
                await Task.Delay(30);
            }
        }

        private void OnTimedEvent(Object? source, ElapsedEventArgs e)
        {
            string s = ConsoleText[^1] switch
            {
                '/' => "\\",
                '|' => "/",
                _ => "|",
            };
            ReplaceLastSymbolInConsoleText(s);
        }

        private void ReplaceLastSymbolInConsoleText(string s)
        {
            ConsoleText = ConsoleText.Remove(ConsoleText.Length - 1) + s;
        }
        #endregion
        #endregion
    }
}