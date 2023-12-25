using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.Settings;
using SpaceResidentClient.ViewModels.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.MainMenu.Settings
{
    partial class VideoSettingsViewModel : ObservableObject
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        #region props
        [ObservableProperty]
        public static TextBlock? selectedScreenModeTextBlock;
        [ObservableProperty]
        public ObservableCollection<TextBlock> screenModeTextBlocks;
        #endregion

        #region commands
        private void CbScreenModeSelectionChanged()
        {
            if (SelectedScreenModeTextBlock != null)
            {
                // fullscreen
                if (SelectedScreenModeTextBlock.Text == Properties.Lang.fullscreen)
                    ChangeWindowMode(windowModes[0]);
                // windowed
                else if (SelectedScreenModeTextBlock.Text == Properties.Lang.windowed)
                    ChangeWindowMode(windowModes[1]);
                // borderless window
                else
                    ChangeWindowMode(windowModes[2]);
            }
        }

        public ICommand CbScreenModeSelectionChangedCommand { get; }
        #endregion

        private static readonly WindowMode[] windowModes =
        {
            new(WindowStyle.None, WindowState.Maximized, ResizeMode.NoResize),
            new(WindowStyle.ThreeDBorderWindow, WindowState.Normal, ResizeMode.CanResize),
            new(WindowStyle.None, WindowState.Normal, ResizeMode.NoResize)
        };

        private void ChangeWindowMode(WindowMode windowMode)
        {
            _mainWindowViewModel.WinStyle = windowMode.Style;
            _mainWindowViewModel.WinState = windowMode.State;
            _mainWindowViewModel.ResizeMode = windowMode.ResizeMode;
        }

        public VideoSettingsViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            CbScreenModeSelectionChangedCommand = new RelayCommand(CbScreenModeSelectionChanged);

            screenModeTextBlocks =
            [
                new() { Text = Properties.Lang.fullscreen },
                new() { Text = Properties.Lang.windowed },
                new() { Text = Properties.Lang.borderlessWindow }
            ];
        }
    }
}