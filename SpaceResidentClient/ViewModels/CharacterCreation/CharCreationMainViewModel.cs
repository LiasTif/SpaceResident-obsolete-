﻿using CommunityToolkit.Mvvm.ComponentModel;
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
                    SetTabToCurrentUserControl(typeof(CharCreationPersonalityViewModel));
                    break;
                case "skills":
                    SetTabToCurrentUserControl(typeof(CharCreationSkillsViewModel));
                    break;
                case "job":
                    SetTabToCurrentUserControl(typeof(CharCreationJobViewModel));
                    break;
                case "location":
                    SetTabToCurrentUserControl(typeof(CharCreationLocationViewModel));
                    break;
                case "stats":
                    SetTabToCurrentUserControl(typeof(CharCreationStatsViewModel));
                    break;
            }
        }

        private void SetTabToCurrentUserControl(Type type)
        {
            CharacterCreationTabsBuffer b = new();

            CurrentUserControl = b.GetTabFromCollection(type, PortraitVM);
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
                new() { CommandParameter = "character", IsChecked = true },
                new() { CommandParameter = "skills", },
                new() { CommandParameter = "job", },
                new() { CommandParameter = "location", },
                new() { CommandParameter = "stats", }
            ];

            // set default values to items in collection
            foreach (RadioButton rbtn in buttonsCollection)
            {
                rbtn.Command = OpenSomeMenuCommand;
                rbtn.Style = (Style)baseResourceDictionary["rbtnCharacteriscticMain"];
                rbtn.GroupName = "rbtns";
            }

            return buttonsCollection;
        }
        #endregion
    }
}