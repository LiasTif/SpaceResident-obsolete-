using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models;
using SpaceResidentClient.Models.CharacterCreation;
using SpaceResidentClient.ViewModels.MainMenu;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SpaceResidentClient.Services.UISounds;
using SpaceResidentClient.ViewModels.Windows.Interfaces;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharCreationMainViewModel : ObservableObject
    {
        #region fields
        private readonly IWindowNavigationStore _windowViewModel;
        private readonly IWindowScreenMode _windowScreenMode;
        public static MainCharacter MainCharacter = new
        (
            job: "Unemployed",
            name: String.Empty,
            sName: String.Empty,
            isFemale: true,
            race: 'l',
            age: 20
        );
        #endregion

        public CharCreationMainViewModel(IWindowNavigationStore windowViewModel, IWindowScreenMode windowScreenMode)
        {
            PortraitVM = new PortraitViewModel();

            _windowViewModel = windowViewModel;
            _windowScreenMode = windowScreenMode;

            // open character menu by default
            OpenSomeMenu("character");

            NavigateButtons = CreateNavigateButtons();
        }

        #region props
        [ObservableProperty]
        public ObservableCollection<RadioButton> navigateButtons;
        [ObservableProperty]
        public ObservableObject? currentUserControl;
        public PortraitViewModel PortraitVM { get; private set; }
        #endregion

        #region commands
        public ICommand CloseCommand { get => new RelayCommand(Close); }
        public ICommand OpenSomeMenuCommand { get => new RelayCommand<object>(OpenSomeMenu); }
        public ICommand NextPageCommand { get => new RelayCommand(NextPage); }
        public ICommand PreviousPageCommand { get => new RelayCommand(PreviousPage); }
        #endregion

        #region methods
        private void Close()
        {
            _windowViewModel.NavigationStore.CurrentViewModel = new MainMenuViewModel(_windowViewModel, _windowScreenMode);
        }

        private void OpenSomeMenu(object? name)
        {
            var str = name as string;

            switch (str)
            {
                case "character":
                    SetTabToCurrentUserControl(new CharCreationPersonalityViewModel(PortraitVM));
                    break;
                case "skills":
                    SetTabToCurrentUserControl(new CharCreationSkillsViewModel());
                    break;
                case "job":
                    SetTabToCurrentUserControl(new CharCreationJobViewModel(PortraitVM));
                    break;
                case "location":
                    SetTabToCurrentUserControl(new CharCreationLocationViewModel());
                    break;
                case "stats":
                    SetTabToCurrentUserControl(new CharCreationStatsViewModel());
                    break;
            }
        }

        private void SetTabToCurrentUserControl(ObservableObject instance)
        {
            CharacterCreationPagesBuffer b = new();

            CurrentUserControl = b.GetTabFromCollection(instance);
        }

        private void PreviousPage() => LoadNewPage(false);

        private void NextPage() => LoadNewPage(true);

        private void LoadNewPage(bool isNext)
        {
            NavigateTabsByButtonsProcessor navigateTabsByButtonsProcessor = new(NavigateButtons);
            navigateTabsByButtonsProcessor.NavigateTabs(isNext);
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