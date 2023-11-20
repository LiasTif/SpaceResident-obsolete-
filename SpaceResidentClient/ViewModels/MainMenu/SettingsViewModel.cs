using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal class SettingsViewModel : ObservableObject
    {
        public MainMenuViewModel _mainMenuViewModelInstance;

        #region commands
        private void Close() => _mainMenuViewModelInstance.SettingsViewSwitch();
        public ICommand CloseCommand { get; }
        #endregion

        public SettingsViewModel(MainMenuViewModel mainMenuViewModel)
        {
            _mainMenuViewModelInstance = mainMenuViewModel;
            CloseCommand = new RelayCommand(Close);
        }
    }
}