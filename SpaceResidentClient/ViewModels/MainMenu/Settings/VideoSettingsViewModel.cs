using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.Settings;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SpaceResidentClient.Properties;
using SpaceResidentClient.ViewModels.Windows.Interfaces;
using System.Linq;

namespace SpaceResidentClient.ViewModels.MainMenu.Settings
{
    partial class VideoSettingsViewModel : ObservableObject
    {
        private readonly IWindowScreenMode _windowScreenMode;

        public VideoSettingsViewModel(IWindowScreenMode windowScreenMode)
        {
            _windowScreenMode = windowScreenMode;

            ScreenModeSelectionChangedCommand = new RelayCommand(ScreenModeSelectionChanged);
            SetScreenModeTextBlocksCollection();
            SelectedScreenModeTextBlock = ScreenModeTextBlocks[0];
        }

        #region props
        [ObservableProperty]
        public static TextBlock? selectedScreenModeTextBlock;
        [ObservableProperty]
        public ObservableCollection<TextBlock> screenModeTextBlocks = [];
        #endregion

        #region commands
        public ICommand ScreenModeSelectionChangedCommand { get; }
        #endregion

        private void ScreenModeSelectionChanged()
        {
            if (SelectedScreenModeTextBlock != null)
            {
                // fullscreen
                if (SelectedScreenModeTextBlock.Text == Lang.fullscreen)
                    SearchWindowModes(Lang.fullscreen);
                // windowed
                else if (SelectedScreenModeTextBlock.Text == Lang.windowed)
                    SearchWindowModes(Lang.windowed);
                // borderless window
                else if (SelectedScreenModeTextBlock.Text == Lang.borderlessWindow)
                    SearchWindowModes(Lang.borderlessWindow);
            }
        }

        private void SearchWindowModes(string str)
        {
            foreach (var windowMode in windowModes.Where(windowMode => windowMode.ModeName.Contains(str)))
            {
                _windowScreenMode.UpdateScreenMode(windowMode);
            }
        }

        private void SetScreenModeTextBlocksCollection()
        {
            foreach (WindowMode windowMode in windowModes)
            {
                ScreenModeTextBlocks.Add(new() { Text = windowMode.ModeName });
            }
        }

        private static readonly WindowMode[] windowModes =
        {
            new(WindowStyle.None, WindowState.Maximized, ResizeMode.NoResize, Lang.fullscreen),
            new(WindowStyle.ThreeDBorderWindow, WindowState.Normal, ResizeMode.CanResize, Lang.windowed),
            new(WindowStyle.None, WindowState.Normal, ResizeMode.NoResize, Lang.borderlessWindow)
        };
    }
}