using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models;
using SpaceResidentClient.Models.ImagesProcessors;
using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.MainMenu;
using SpaceResidentClient.ViewModels.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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

        private string? _imagesDirectory;

        public string? ImagesDirectory
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
        public ObservableCollection<RadioButton> navigateButtons;
        [ObservableProperty]
        public string? imageSource;
        [ObservableProperty]
        public ObservableObject? currentUserControl;
        #endregion

        #region commands
        private void Close() => _navigationStore.CurrentViewModel = new MainMenuViewModel(_mainWindowViewModel);
        private void OpenJobMenu() => CurrentUserControl = new CreationJobViewModel();
        private void OpenCharacterMenu() => CurrentUserControl = new CreationCharacterViewModel(this);
        private void OpenSkillsMenu() => CurrentUserControl = new CreationSkillsViewModel();
        private void NextImage()
        {
            // set next image or set first image if it`s end of images collection
            ImageIndex = ImageIndex >= ImageCount - 1 ? 1 : ImageIndex + 1;
            ImageSource = "/Resources;component" + _imagesDirectory + ImageIndex + ".png";
        }
        private void PreviousImage()
        {
            // set previous image or set last image if it`s start of images collection
            ImageIndex = ImageIndex <= 1 ? ImageCount - 1 : ImageIndex - 1;
            ImageSource = "/Resources;component" + _imagesDirectory + ImageIndex + ".png";
        }

        private void PreviousPage()
        {
            NavigatePagesByButtonsProcessor navigatePagesByButtonsProcessor = new(NavigateButtons);
            navigatePagesByButtonsProcessor.NavigatePages(false);
        }

        private void NextPage()
        {
            NavigatePagesByButtonsProcessor navigatePagesByButtonsProcessor = new(NavigateButtons);
            navigatePagesByButtonsProcessor.NavigatePages(true);
        }

        public ICommand CloseCommand { get; }
        public ICommand OpenCharacterMenuCommand { get; }
        public ICommand OpenSkillsMenuCommand { get; }
        public ICommand OpenJobMenuCommand { get; }
        public ICommand NextImageCommand { get; }
        public ICommand PreviousImageCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        #endregion

        #region methods
        private ObservableCollection<RadioButton> CreateNavigateButtons()
        {
            // styles for navigate buttons
            var baseResourceDictionary = new ResourceDictionary
            {
                Source = new Uri("/ResourceDictionaries;component/CharacterCreation/CharacterCreationDictionary.xaml",
                                UriKind.RelativeOrAbsolute)
            };

            return
            [
                new()
                {
                    IsChecked = true,
                    Command = OpenCharacterMenuCommand,
                    Style = (Style)baseResourceDictionary["rbtnCharacterMenu"],
                    GroupName = "rbtns"
                },
                new()
                {
                    Command = OpenSkillsMenuCommand,
                    Style = (Style)baseResourceDictionary["rbtnSkillsMenu"],
                    GroupName = "rbtns"
                },
                new()
                {
                    Command = OpenJobMenuCommand,
                    Style = (Style)baseResourceDictionary["rbtnJobMenu"],
                    GroupName = "rbtns"
                }
            ];
        }
        #endregion

        public CharacterCreationViewModel(MainWindowViewModel mainWindowViewModel, NavigationStore navigationStore)
        {
            _imageProcessor = new(this);
            _mainWindowViewModel = mainWindowViewModel;
            _navigationStore = navigationStore;

            CloseCommand = new RelayCommand(Close);
            OpenCharacterMenuCommand = new RelayCommand(OpenCharacterMenu);
            OpenSkillsMenuCommand = new RelayCommand(OpenSkillsMenu);
            OpenJobMenuCommand = new RelayCommand(OpenJobMenu);
            NextImageCommand = new RelayCommand(NextImage);
            PreviousImageCommand = new RelayCommand(PreviousImage);
            NextPageCommand = new RelayCommand(NextPage);
            PreviousPageCommand = new RelayCommand(PreviousPage);

            // open character menu by default
            OpenCharacterMenu();

            NavigateButtons = CreateNavigateButtons();
        }
    }
}