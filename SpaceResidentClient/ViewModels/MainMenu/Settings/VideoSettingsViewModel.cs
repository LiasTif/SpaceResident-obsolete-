using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.Settings;
using System.Windows;
using System.Windows.Input;
using SpaceResidentClient.Properties;
using SpaceResidentClient.ViewModels.Windows.Interfaces;
using System.Linq;
using SpaceResidentClient.Models;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace SpaceResidentClient.ViewModels.MainMenu.Settings
{
    partial class VideoSettingsViewModel : ComboBoxesRealization
    {
        private readonly IWindowScreenMode _windowScreenMode;

        public VideoSettingsViewModel(IWindowScreenMode windowScreenMode)
        {
            _windowScreenMode = windowScreenMode;

            TextBlocks = SetTBCollection();
            UpdateSelectedTB(GetNameOfCurrentTextBlock());
        }

        #region commands
        public ICommand ScreenModeSelectionChangedCommand { get => new RelayCommand(ScreenModeSelectionChanged); }
        #endregion

        private void ScreenModeSelectionChanged()
        {
            if (SelectedTextBlock == null)
                return;

            SearchWindowModes(SelectedTextBlock.Text);
        }

        private void SearchWindowModes(string str)
        {
            foreach (var windowMode in windowModes.Where(windowMode => windowMode.ModeName.Equals(str)))
            {
                _windowScreenMode.UpdateScreenMode(windowMode);
            }
        }

        private protected override ObservableCollection<TextBlock> SetTBCollection()
        {
            ObservableCollection<TextBlock> result = [];
            foreach (WindowMode windowMode in windowModes)
            {
                result.Add(new() { Text = windowMode.ModeName });
            }

            return result;
        }

        public string GetNameOfCurrentTextBlock()
        {
            string result = string.Empty;

            foreach (var windowMode in windowModes)
            {
                if (windowMode.ModeName == _windowScreenMode.ModeName)
                    result = windowMode.ModeName;
            }

            return result;
        }

        private static readonly WindowMode[] windowModes =
        {
            new(WindowStyle.None, WindowState.Maximized, ResizeMode.NoResize, Lang.fullscreen),
            new(WindowStyle.ThreeDBorderWindow, WindowState.Normal, ResizeMode.CanResize, Lang.windowed),
            new(WindowStyle.None, WindowState.Normal, ResizeMode.NoResize, Lang.borderlessWindow)
        };
    }
}