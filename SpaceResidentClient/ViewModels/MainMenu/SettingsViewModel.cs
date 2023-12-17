using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.ViewModels.MainMenu.Settings;
using SpaceResidentClient.ViewModels.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Windows.Foundation.Metadata;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal partial class SettingsViewModel : ObservableObject
    {
        public MainMenuViewModel _mainMenuViewModelInstance;
        private readonly MainWindowViewModel _mainWindowViewModel;

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
        private void PreviousPage()
        {
            NavigatePage(false);
        }

        private void NextPage()
        {
            NavigatePage(true);
        }

        private void NavigatePage(bool isNext)
        {
            if (MenuButtons.Count < 2)
                return;

            for (int i = 0; i < MenuButtons.Count; i++)
            {
                if (isNext && i != MenuButtons.Count - 1 && MenuButtons[i].IsChecked == true)
                {
                    MenuButtons[i].IsChecked = false;
                    MenuButtons[i + 1].IsChecked = true;
                    MenuButtons[i + 1].Command.Execute(null);
                }
                else if (!isNext && i - 1 >= 0 && MenuButtons[i].IsChecked == true)
                {
                    MenuButtons[i].IsChecked = false;
                    MenuButtons[i - 1].IsChecked = true;
                    MenuButtons[i - 1].Command.Execute(null);
                }
            }
        }

        public ICommand CloseCommand { get; }
        public ICommand OpenGamePageCommand { get; }
        public ICommand OpenVideoPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }
        #endregion

        public SettingsViewModel(MainMenuViewModel mainMenuViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _mainMenuViewModelInstance = mainMenuViewModel;

            CloseCommand = new RelayCommand(Close);
            OpenGamePageCommand = new RelayCommand(OpenGamePage);
            OpenVideoPageCommand = new RelayCommand(OpenVideoPage);
            PreviousPageCommand = new RelayCommand(PreviousPage);
            NextPageCommand = new RelayCommand(NextPage);

            MenuButtons =
            [
                new() {
                    Content = Properties.Lang.game,
                    Command = OpenGamePageCommand,
                    GroupName = "rbtns",
                    IsChecked = true},
                new() {Content = Properties.Lang.video, Command = OpenVideoPageCommand, GroupName = "rbtns"}
            ];
        }
    }
}