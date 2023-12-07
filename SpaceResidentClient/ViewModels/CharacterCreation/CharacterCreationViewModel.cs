using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.ImagesProcessors;
using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.MainMenu;
using SpaceResidentClient.ViewModels.Windows;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharacterCreationViewModel : ObservableObject
    {
        public readonly CharacterImageProcessor _imageProcessor;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly NavigationStore _navigationStore;

        #region props
        public int ImageIndex { private get; set; } = 0;
        public int ImageCount { private get; set; }

        private string _imagesDirectory;

        public string ImagesDirectory
        {
            get => _imagesDirectory;
            set
            {
                if (_imagesDirectory != value)
                {
                    _imagesDirectory = value;
                    ImageSource = "/Resources;component" + _imagesDirectory + ImageIndex + ".png";
                }
            }
        }

        [ObservableProperty]
        public string imageSource;
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
            if (ImageIndex >= ImageCount - 1)
            {
                ImageIndex = 1;
                ImageSource = "/Resources;component" + _imagesDirectory + ImageIndex + ".png";
            }
            else
                ImageSource = "/Resources;component" + _imagesDirectory + ++ImageIndex + ".png";
        }
        private void PreviousImage()
        {
            if (ImageIndex <= 1)
            {
                ImageIndex = ImageCount - 1;
                ImageSource = "/Resources;component" + _imagesDirectory + ImageIndex + ".png";
            }
            else
                ImageSource = "/Resources;component" + _imagesDirectory + --ImageIndex + ".png";
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