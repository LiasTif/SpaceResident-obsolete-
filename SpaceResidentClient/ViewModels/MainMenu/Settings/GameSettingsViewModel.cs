using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.ViewModels.MainMenu.Settings
{
    partial class GameSettingsViewModel : ObservableObject
    {
        #region props
        [ObservableProperty]
        public TextBlock selectedLanguageTextBlock = new();
        [ObservableProperty]
        public ObservableCollection<TextBlock> languageTextBlocks;
        #endregion

        #region commands
        private void LanguageSelectionChanged()
        {
            if (Lang.ua == SelectedLanguageTextBlock.Text)
                Properties.Settings.Default.languageCode = "uk-UA";
            else
                Properties.Settings.Default.languageCode = "en-US";

            Properties.Settings.Default.Save();
        }
        public ICommand LanguageSelectionChangedCommand { get; }
        #endregion

        public GameSettingsViewModel()
        {
            LanguageSelectionChangedCommand = new RelayCommand(LanguageSelectionChanged);

            languageTextBlocks =
            [
                new() { Text = Lang.ua},
                new() { Text = Lang.en}
            ];

            if (Properties.Settings.Default.languageCode == "uk-UA")
                SelectedLanguageTextBlock.Text = Lang.ua;
            else if (Properties.Settings.Default.languageCode == "en-US")
                SelectedLanguageTextBlock.Text = Lang.en;
        }
    }
}