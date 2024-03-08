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
            if (ImageProcessor == null)
                BgImageSource = (ImageProcessor = new(this)).SetBgImageSource(Lang.unemployed);

            _mainWindowViewModel = mainWindowViewModel;
            _navigationStore = mainWindowViewModel.NavigationStore;

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
        public string? bgImageSource;
        [ObservableProperty]
        public ObservableObject? currentUserControl;
        #endregion

        #region commands
        public ICommand CloseCommand { get => new RelayCommand(Close); }

        public ICommand OpenSomeMenuCommand { get => new RelayCommand<object>(OpenSomeMenu); }

        public ICommand NextImageCommand { get => new RelayCommand(NextImage); }
        public ICommand PreviousImageCommand { get => new RelayCommand(PreviousImage); }
        public ICommand NextPageCommand { get => new RelayCommand(NextPage); }
        public ICommand PreviousPageCommand { get => new RelayCommand(PreviousPage); }

        private void Close()
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_mainWindowViewModel);
        }

        private void OpenSomeMenu(object? name)
        {
            var str = name as string;

            switch (str)
            {
                case "character":
                    SetPageToCurrentUserControl(typeof(CreationCharacterViewModel), new CreationCharacterViewModel(this));
                    break;
                case "skills":
                    SetPageToCurrentUserControl(typeof(CreationSkillsViewModel), new CreationSkillsViewModel());
                    break;
                case "job":
                    SetPageToCurrentUserControl(typeof(CreationJobViewModel), new CreationJobViewModel(this));
                    break;
                case "location":
                    SetPageToCurrentUserControl(typeof(CreationLocationViewModel), new CreationLocationViewModel());
                    break;
                case "stats":
                    SetPageToCurrentUserControl(typeof(CreationStatsViewModel), new CreationStatsViewModel());
                    break;
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

        private void PreviousPage() => LoadNewPage(false);

        private void NextPage() => LoadNewPage(true);

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
                Source = new Uri("/ResourceDictionaries;component/Client/CharacterCreation/CharacterCreationDictionary.xaml",
                    UriKind.RelativeOrAbsolute)
            };

            ObservableCollection<RadioButton> buttonsCollection =
            [
                new()
                {
                    IsChecked = true,
                    CommandParameter = "character",
                    Style = (Style)baseResourceDictionary["rbtnCharacterMenu"]
                },
                new()
                {
                    CommandParameter = "skills",
                    Style = (Style)baseResourceDictionary["rbtnSkillsMenu"]
                },
                new()
                {
                    CommandParameter = "job",
                    Style = (Style)baseResourceDictionary["rbtnJobMenu"]
                },
                new()
                {
                    CommandParameter = "location",
                    Style = (Style)baseResourceDictionary["rbtnLocationMenu"],
                },
                new()
                {
                    CommandParameter = "stats",
                    Style = (Style)baseResourceDictionary["rbtnStatsMenu"]
                }
            ];

            // set default values to items in collection
            foreach (RadioButton rbtn in buttonsCollection)
            {
                rbtn.Command = OpenSomeMenuCommand;
                rbtn.GroupName = "rbtns";
            }

            return buttonsCollection;
        }
        #endregion
    }
}