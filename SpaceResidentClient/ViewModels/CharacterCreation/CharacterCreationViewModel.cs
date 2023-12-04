using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharacterCreationViewModel : ObservableObject
    {
        #region props
        [ObservableProperty]
        public ObservableObject currentUserControl = new CreationCharacterViewModel();
        #endregion

        #region commands
        private void OpenJobMenu() => CurrentUserControl = new CreationJobViewModel();
        private void OpenCharacterMenu() => CurrentUserControl = new CreationCharacterViewModel();
        private void OpenSkillsMenu() => CurrentUserControl = new CreationSkillsViewModel();
        public ICommand OpenJobMenuCommand { get; }
        public ICommand OpenCharacterMenuCommand { get; }
        public ICommand OpenSkillsMenuCommand { get; }
        #endregion

        public CharacterCreationViewModel()
        {
            OpenJobMenuCommand = new RelayCommand(OpenJobMenu);
            OpenCharacterMenuCommand = new RelayCommand(OpenCharacterMenu);
            OpenSkillsMenuCommand = new RelayCommand(OpenSkillsMenu);
        }
    }
}
