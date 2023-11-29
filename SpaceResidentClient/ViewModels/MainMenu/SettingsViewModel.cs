using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.ViewModels.MainMenu.Settings;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal partial class SettingsViewModel : ObservableObject
    {
        public MainMenuViewModel _mainMenuViewModelInstance;

        #region props
        [ObservableProperty]
        public ObservableCollection<RadioButton> menuButtons;
        [ObservableProperty]
        public ObservableObject currentPage = new GameSettingsViewModel();
        #endregion

        #region commands
        private void Close() => _mainMenuViewModelInstance.SettingsViewSwitch();
        private void OpenGamePage() => CurrentPage = new GameSettingsViewModel();
        private void OpenVideoPage() => CurrentPage = new VideoSettingsViewModel();
        public ICommand CloseCommand { get; }
        public ICommand OpenGamePageCommand { get; }
        public ICommand OpenVideoPageCommand { get; }
        #endregion

        public SettingsViewModel(MainMenuViewModel mainMenuViewModel)
        {
            _mainMenuViewModelInstance = mainMenuViewModel;
            CloseCommand = new RelayCommand(Close);
            OpenGamePageCommand = new RelayCommand(OpenGamePage);
            OpenVideoPageCommand = new RelayCommand(OpenVideoPage);

            menuButtons = new ObservableCollection<RadioButton>()
            {
                new RadioButton() {
                    Content = "Game",
                    Command = OpenGamePageCommand,
                    GroupName = "rbtns",
                    IsChecked = true},
                new RadioButton() {Content = "Video", Command = OpenVideoPageCommand, GroupName = "rbtns"}
            };
        }
    }
}