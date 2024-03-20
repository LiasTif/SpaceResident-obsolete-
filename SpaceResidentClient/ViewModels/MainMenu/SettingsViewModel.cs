using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models;
using SpaceResidentClient.ViewModels.MainMenu.Settings;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using SpaceResidentClient.Properties;
using SpaceResidentClient.Services.UISounds;
using SpaceResidentClient.ViewModels.Windows.Interfaces;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal partial class SettingsViewModel : ObservableObject
    {
        private readonly IWindowScreenMode _windowScreenMode;
        public MainMenuViewModel _mainMenuViewModelInstance;

        public SettingsViewModel(MainMenuViewModel mainMenuViewModel, IWindowScreenMode windowScreenMode)
        {
            _windowScreenMode = windowScreenMode;
            _mainMenuViewModelInstance = mainMenuViewModel;

            CloseCommand = new RelayCommand(Close);
            OpenGamePageCommand = new RelayCommand(OpenGamePage);
            OpenVideoPageCommand = new RelayCommand(OpenVideoPage);
            PreviousPageCommand = new RelayCommand(PreviousPage);
            NextPageCommand = new RelayCommand(NextPage);

            MenuButtons = CreateMenuButtons();
        }

        #region props
        [ObservableProperty]
        public ObservableCollection<RadioButton> menuButtons;
        [ObservableProperty]
        public ObservableObject currentPage = new GameSettingsViewModel();
        #endregion

        #region commands
        private void Close() => _mainMenuViewModelInstance.SettingsViewSwitch();
        private void OpenGamePage() => CurrentPage = new GameSettingsViewModel();
        private void OpenVideoPage() => CurrentPage = new VideoSettingsViewModel(_windowScreenMode);
        private void PreviousPage() => SwitchPage(false);
        private void NextPage() => SwitchPage(true);

        public ICommand CloseCommand { get; }
        public ICommand OpenGamePageCommand { get; }
        public ICommand OpenVideoPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }
        #endregion

        #region methods
        private void SwitchPage(bool isNext)
        {
            NavigateTabsByButtonsProcessor navigateTabsByButtonsProcessor = new(MenuButtons);
            navigateTabsByButtonsProcessor.NavigateTabs(isNext);
            ArrowButtonClickPlayer.LoadClickPlayer();
        }

        private ObservableCollection<RadioButton> CreateMenuButtons()
        {
            return
            [
                new()
                {
                    Content = Lang.game,
                    Command = OpenGamePageCommand,
                    GroupName = "rbtns",
                    IsChecked = true
                },
                new()
                {
                    Content = Lang.video,
                    Command = OpenVideoPageCommand,
                    GroupName = "rbtns"
                }
            ];
        }
        #endregion
    }
}