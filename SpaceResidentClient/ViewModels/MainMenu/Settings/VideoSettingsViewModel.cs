using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.ViewModels.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu.Settings
{
    partial class VideoSettingsViewModel : ObservableObject
    {
        private MainWindowViewModel _mainWindowViewModel;

        #region props
        [ObservableProperty]
        public TextBlock selectedScreenModeTextBlock;
        [ObservableProperty]
        public ObservableCollection<TextBlock> screenModeTextBlocks;
        #endregion

        #region commands
        private void CbScreenModeSelectionChanged()
        {
            switch (SelectedScreenModeTextBlock.Text)
            {
                // fullscreen
                case "Fullscreen":
                    _mainWindowViewModel.WinStyle = WindowStyle.None;
                    _mainWindowViewModel.WinState = WindowState.Maximized;
                    _mainWindowViewModel.ResizeMode = ResizeMode.NoResize;
                    break;
                // windowed
                case "Windowed":
                    _mainWindowViewModel.WinStyle = WindowStyle.ThreeDBorderWindow;
                    _mainWindowViewModel.WinState = WindowState.Normal;
                    _mainWindowViewModel.ResizeMode = ResizeMode.CanResize;
                    break;
                // borderless window
                default:
                    _mainWindowViewModel.WinStyle = WindowStyle.None;
                    _mainWindowViewModel.WinState = WindowState.Normal;
                    _mainWindowViewModel.ResizeMode = ResizeMode.NoResize;
                    break;
            }
            
        }
        public ICommand CbScreenModeSelectionChangedCommand { get; }
        #endregion

        public VideoSettingsViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            CbScreenModeSelectionChangedCommand = new RelayCommand(CbScreenModeSelectionChanged);

            screenModeTextBlocks = new ObservableCollection<TextBlock>()
            {
                new TextBlock() { Text = "Fullscreen"},
                new TextBlock() { Text = "Windowed"},
                new TextBlock() { Text = "Borderless Window"}
            };
        }
    }
}