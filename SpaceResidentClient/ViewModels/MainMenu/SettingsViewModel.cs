using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.ViewModels.MainMenu.Settings;
using SpaceResidentClient.ViewModels.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal partial class SettingsViewModel : ObservableObject
    {
        public MainMenuViewModel _mainMenuViewModelInstance;
        private MainWindowViewModel _mainWindowViewModel;

        #region props
        [ObservableProperty]
        public ObservableCollection<RadioButton> menuButtons;
        [ObservableProperty]
        public ObservableObject currentPage = new GameSettingsViewModel();
        #endregion

        #region commands
        private void Close() => _mainMenuViewModelInstance.SettingsViewSwitch();
        private void OpenGamePage() => CurrentPage = new GameSettingsViewModel();
        private void OpenVideoPage() => CurrentPage = new VideoSettingsViewModel(_mainWindowViewModel);
        public ICommand CloseCommand { get; }
        public ICommand OpenGamePageCommand { get; }
        public ICommand OpenVideoPageCommand { get; }
        #endregion

        public SettingsViewModel(MainMenuViewModel mainMenuViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
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