using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.MainMenu;
using SpaceResidentClient.ViewModels.Windows;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharacterCreationViewModel : ObservableObject
    {
        private MainWindowViewModel _mainWindowViewModel;
        private NavigationStore _navigationStore;

        #region props
        [ObservableProperty]
        public ObservableObject currentUserControl = new CreationCharacterViewModel();
        #endregion

        #region commands
        private void Close() => _navigationStore.CurrentViewModel = new MainMenuViewModel(_mainWindowViewModel, _navigationStore);
        private void OpenJobMenu() => CurrentUserControl = new CreationJobViewModel();
        private void OpenCharacterMenu() => CurrentUserControl = new CreationCharacterViewModel();
        private void OpenSkillsMenu() => CurrentUserControl = new CreationSkillsViewModel();
        public ICommand CloseCommand { get; }
        public ICommand OpenJobMenuCommand { get; }
        public ICommand OpenCharacterMenuCommand { get; }
        public ICommand OpenSkillsMenuCommand { get; }
        #endregion

        public CharacterCreationViewModel(MainWindowViewModel mainWindowViewModel, NavigationStore navigationStore)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _navigationStore = navigationStore;

            CloseCommand = new RelayCommand(Close);
            OpenJobMenuCommand = new RelayCommand(OpenJobMenu);
            OpenCharacterMenuCommand = new RelayCommand(OpenCharacterMenu);
            OpenSkillsMenuCommand = new RelayCommand(OpenSkillsMenu);
        }
    }
}
