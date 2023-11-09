using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu
{
    internal class SettingsViewModel : ObservableObject
    {
        public MainMenuViewModel _dataContext;

        #region commands
        private void Close() => _dataContext.CurrentUCViewModel = null;
        public ICommand CloseCommand { get; }
        #endregion

        public SettingsViewModel(MainMenuViewModel dataContext)
        {
            _dataContext = dataContext;
            CloseCommand = new RelayCommand(Close);
        }
    }
}