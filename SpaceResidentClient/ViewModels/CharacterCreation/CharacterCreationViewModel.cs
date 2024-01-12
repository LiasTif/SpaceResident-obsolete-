using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models;
using SpaceResidentClient.Models.CharacterCreation;
using SpaceResidentClient.Models.ImagesProcessors;
using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.MainMenu;
using SpaceResidentClient.ViewModels.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SpaceResidentClient.Properties;
using SpaceResidentClient.Services.UISounds;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharacterCreationViewModel : ObservableObject
    {
        #region fields
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly NavigationStore _navigationStore;
        public CharacterImageProcessor ImageProcessor;
        public static MainCharacter MainCharacter = new
        (
            job: "Unemployed",
            name: String.Empty,
            surname: String.Empty,
            isFemale: true,
            race: 'l',
            age: 20
        );
        #endregion

        public CharacterCreationViewModel(MainWindowViewModel mainWindowViewModel)
        {
            // set bg as unemployed by default
            BgImageSource = (ImageProcessor = new(this)).SetBgImageSource(Lang.unemployed);

            _mainWindowViewModel = mainWindowViewModel;
            _navigationStore = mainWindowViewModel.NavigationStore;

            CloseCommand = new RelayCommand(Close);

            OpenCharacterMenuCommand = new RelayCommand<object>(OpenSomeMenu);
            OpenSkillsMenuCommand = new RelayCommand<object>(OpenSomeMenu);
            OpenJobMenuCommand = new RelayCommand<object>(OpenSomeMenu);
            OpenLocationMenuCommand = new RelayCommand<object>(OpenSomeMenu);
            OpenStatsMenuCommand = new RelayCommand<object>(OpenSomeMenu);

            NextImageCommand = new RelayCommand(NextImage);
            PreviousImageCommand = new RelayCommand(PreviousImage);
            NextPageCommand = new RelayCommand(NextPage);
            PreviousPageCommand = new RelayCommand(PreviousPage);

            // open character menu by default
            OpenSomeMenu("character");

            NavigateButtons = CreateNavigateButtons();
        }

        #region props
        public int ImageIndex { private get; set; } = 0;
        public int ImageCount { private get; set; }

        private string? _characterImagesDirectory;

        public string? CharacterImagesDirectory
        {
            get => _characterImagesDirectory;
            set
            {
                if (_characterImagesDirectory != value)
                {
                    _characterImagesDirectory = value;
                    ImageSource = "/Resources;component" + _characterImagesDirectory + ImageIndex + ".png";
                }
            }
        }

        [ObservableProperty]
        public ObservableCollection<RadioButton> navigateButtons;
        [ObservableProperty]
        public string imageSource = String.Empty;
        [ObservableProperty]
        public string bgImageSource;
        [ObservableProperty]
        public ObservableObject? currentUserControl;
        #endregion

        #region commands
        public ICommand CloseCommand { get; }

        public ICommand OpenCharacterMenuCommand { get; }
        public ICommand OpenSkillsMenuCommand { get; }
        public ICommand OpenJobMenuCommand { get; }
        public ICommand OpenLocationMenuCommand { get; }
        public ICommand OpenStatsMenuCommand { get; }

        public ICommand NextImageCommand { get; }
        public ICommand PreviousImageCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        private void Close()
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_mainWindowViewModel);
            CharacterCreationPagesBuffer.PagesCollection = null;
        }

        private void OpenSomeMenu(object name)
        {
            var str = name as string;

            if (str == "character")
            {
                SetPageToCurrentUserControl(typeof(CreationCharacterViewModel), new CreationCharacterViewModel(this));
            }
            else if (str == "skills")
            {
                SetPageToCurrentUserControl(typeof(CreationSkillsViewModel), new CreationSkillsViewModel());
            }
            else if (str == "job")
            {
                SetPageToCurrentUserControl(typeof(CreationJobViewModel), new CreationJobViewModel(this));
            }
            else if (str == "location")
            {
                SetPageToCurrentUserControl(typeof(CreationLocationViewModel), new CreationLocationViewModel());
            }
            else if (str == "stats")
            {
                SetPageToCurrentUserControl(typeof(CreationStatsViewModel), new CreationStatsViewModel());
            }
        }

        private void SetPageToCurrentUserControl(Type type, ObservableObject instance)
        {
            CurrentUserControl = CharacterCreationPagesBuffer.GetPageFromCollection(type);
            if (CurrentUserControl == null)
            {
                CharacterCreationPagesBuffer.AddPageToCollection(instance);
                CurrentUserControl = CharacterCreationPagesBuffer.GetPageFromCollection(type);
            }
        }

        private void NextImage()
        {
            // set next image or set first image if it`s end of images collection
            ImageIndex = ImageIndex >= ImageCount - 1 ? 1 : ImageIndex + 1;
            LoadNewImage();
        }
        private void PreviousImage()
        {
            // set previous image or set last image if it`s start of images collection
            ImageIndex = ImageIndex <= 1 ? ImageCount - 1 : ImageIndex - 1;
            LoadNewImage();
        }

        private void LoadNewImage()
        {
            ImageSource = "/Resources;component" + CharacterImagesDirectory + ImageIndex + ".png";
            ArrowButtonClickPlayer.LoadClickPlayer();
        }

        private void PreviousPage()
        {
            LoadNewPage(false);
        }

        private void NextPage()
        {
            LoadNewPage(true);
        }

        private void LoadNewPage(bool isNext)
        {
            NavigatePagesByButtonsProcessor navigatePagesByButtonsProcessor = new(NavigateButtons);
            navigatePagesByButtonsProcessor.NavigatePages(isNext);
            ArrowButtonClickPlayer.LoadClickPlayer();
        }
        #endregion

        #region buttonsCollection
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
                    CommandParameter = "character",
                    Style = (Style)baseResourceDictionary["rbtnCharacterMenu"],
                    GroupName = "rbtns"
                },
                new()
                {
                    Command = OpenSkillsMenuCommand,
                    CommandParameter = "skills",
                    Style = (Style)baseResourceDictionary["rbtnSkillsMenu"],
                    GroupName = "rbtns"
                },
                new()
                {
                    Command = OpenJobMenuCommand,
                    CommandParameter = "job",
                    Style = (Style)baseResourceDictionary["rbtnJobMenu"],
                    GroupName = "rbtns"
                },
                new()
                {
                    Command = OpenLocationMenuCommand,
                    CommandParameter = "location",
                    Style = (Style)baseResourceDictionary["rbtnLocationMenu"],
                    GroupName = "rbtns"
                },
                new()
                {
                    Command = OpenStatsMenuCommand,
                    CommandParameter = "stats",
                    Style = (Style)baseResourceDictionary["rbtnStatsMenu"],
                    GroupName = "rbtns"
                }
            ];
        }
        #endregion
    }
}