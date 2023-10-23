using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.API;
using SpaceResidentClient.ViewModels.MainMenu;
using System;

namespace SpaceResidentClient.ViewModels.Windows
{
    internal class MainWindowViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            navigationStore.CurrentViewModel = new MainMenuViewModel(navigationStore);
            _navigationStore = navigationStore;

            _navigationStore.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "CurrentViewModel")
                    OnPropertyChanged("CurrentViewModel");
            };

            // load Music Player and set bg music for main menu
            Music.Player.Open(new Uri("Data/music/Menu Music.mp3", UriKind.Relative));
            Music.Player.Play();
        }
    }
}