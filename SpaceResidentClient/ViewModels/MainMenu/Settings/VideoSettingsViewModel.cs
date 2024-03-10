using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.Settings;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SpaceResidentClient.Properties;
using SpaceResidentClient.Interfaces;

namespace SpaceResidentClient.ViewModels.MainMenu.Settings
{
    partial class VideoSettingsViewModel : ObservableObject
    {
        private readonly IWindowScreenMode _windowScreenMode;

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
                if (SelectedScreenModeTextBlock.Text == Lang.fullscreen)
                    _windowScreenMode.UpdateScreenMode(windowModes[0]);
                // windowed
                else if (SelectedScreenModeTextBlock.Text == Lang.windowed)
                    _windowScreenMode.UpdateScreenMode(windowModes[1]);
                // borderless window
                else
                    _windowScreenMode.UpdateScreenMode(windowModes[2]);
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

        //private void ChangeWindowMode(IWindowScreenMode screenMode, WindowMode windowMode)
        //{
        //    screenMode.WinStyle = windowMode.Style;
        //    screenMode.WinState = windowMode.State;
        //    screenMode.ResizeMode = windowMode.ResizeMode;
        //}

        public VideoSettingsViewModel(IWindowScreenMode windowScreenMode)
        {
            _windowScreenMode = windowScreenMode;

            CbScreenModeSelectionChangedCommand = new RelayCommand(CbScreenModeSelectionChanged);

            screenModeTextBlocks =
            [
                new() { Text = Lang.fullscreen },
                new() { Text = Lang.windowed },
                new() { Text = Lang.borderlessWindow }
            ];
        }
    }
}