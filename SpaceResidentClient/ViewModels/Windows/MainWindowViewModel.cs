using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Services;
using SpaceResidentClient.ViewModels.MainMenu;
using System;
using System.Windows;

namespace SpaceResidentClient.ViewModels.Windows
{
    partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private NavigationStore navigationStore;
        public ObservableObject CurrentViewModel => NavigationStore.CurrentViewModel;

        #region props
        [ObservableProperty]
        public ResizeMode resizeMode = ResizeMode.NoResize;
        [ObservableProperty]
        public WindowState winState = WindowState.Maximized;
        [ObservableProperty]
        public WindowStyle winStyle = WindowStyle.None;
        #endregion

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            navigationStore.CurrentViewModel = new MainMenuViewModel(this);
            this.navigationStore = navigationStore;

            this.navigationStore.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "CurrentViewModel")
                    OnPropertyChanged(nameof(CurrentViewModel));
            };

            // load Music Player and set bg music for main menu
            BackgroundMusicPlayer.LoadMusic("Data/music/MenuMusic.mp3");
        }
    }
}