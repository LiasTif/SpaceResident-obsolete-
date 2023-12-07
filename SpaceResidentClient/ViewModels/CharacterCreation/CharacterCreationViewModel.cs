using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.ImagesProcessors;
using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.MainMenu;
using SpaceResidentClient.ViewModels.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharacterCreationViewModel : ObservableObject
    {
        public readonly CharacterImageProcessor _imageProcessor;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly NavigationStore _navigationStore;
        private int _imageIndex = 0;

        #region props
        private ObservableCollection<string> _characterImagesSource;

        public ObservableCollection<string> ImageSources
        {
            get => _characterImagesSource;
            set
            {
                _characterImagesSource = value;
                CharacterImageSource = ImageSources[_imageIndex];
            }
        }
        [ObservableProperty]
        public string? characterImageSource;
        [ObservableProperty]
        public ObservableObject? currentUserControl;
        #endregion

        #region commands
        private void Close() => _navigationStore.CurrentViewModel = new MainMenuViewModel(_mainWindowViewModel, _navigationStore);
        private void OpenJobMenu() => CurrentUserControl = new CreationJobViewModel();
        private void OpenCharacterMenu() => CurrentUserControl = new CreationCharacterViewModel(this);
        private void OpenSkillsMenu() => CurrentUserControl = new CreationSkillsViewModel();
        private void NextImage()
        {
            if (_imageIndex != ImageSources.Count - 1)
                CharacterImageSource = ImageSources[_imageIndex++];
            else
                CharacterImageSource = ImageSources[0];
        }
        private void PreviousImage()
        {
            if (_imageIndex != 0)
                CharacterImageSource = ImageSources[_imageIndex--];
            else
                CharacterImageSource = ImageSources[^1];
        }
        public ICommand CloseCommand { get; }
        public ICommand OpenJobMenuCommand { get; }
        public ICommand OpenCharacterMenuCommand { get; }
        public ICommand OpenSkillsMenuCommand { get; }
        public ICommand NextImageCommand { get; }
        public ICommand PreviousImageCommand { get; }
        #endregion

        public CharacterCreationViewModel(MainWindowViewModel mainWindowViewModel, NavigationStore navigationStore)
        {
            _imageProcessor = new(this);
            _mainWindowViewModel = mainWindowViewModel;
            _navigationStore = navigationStore;

            CloseCommand = new RelayCommand(Close);
            OpenJobMenuCommand = new RelayCommand(OpenJobMenu);
            OpenCharacterMenuCommand = new RelayCommand(OpenCharacterMenu);
            OpenSkillsMenuCommand = new RelayCommand(OpenSkillsMenu);
            NextImageCommand = new RelayCommand(NextImage);
            PreviousImageCommand = new RelayCommand(PreviousImage);
            // open character menu by default
            OpenCharacterMenu();
        }
    }
}