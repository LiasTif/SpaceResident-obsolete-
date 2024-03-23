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
        public GameSettingsViewModel()
        {
            SetSelecterLangTBText();
        }

        #region props
        [ObservableProperty]
        public TextBlock? selectedLanguageTextBlock = null;
        [ObservableProperty]
        public ObservableCollection<TextBlock> languageTextBlocks =
        [
            new() { Text = Lang.ua},
            new() { Text = Lang.en}
        ];
        #endregion

        #region commands
        public ICommand LanguageSelectionChangedCommand { get => new RelayCommand(LanguageSelectionChanged); }
        #endregion

        private void SetSelecterLangTBText()
        {
            if (Properties.Settings.Default.languageCode == "uk-UA")
                SearchLangTextBlocks(Lang.ua);
            else if (Properties.Settings.Default.languageCode == "en-US")
                SearchLangTextBlocks(Lang.en);
        }

        private void SearchLangTextBlocks(string str)
        {
            foreach (TextBlock textBlock in LanguageTextBlocks)
            {
                if (textBlock.Text.Contains(str))
                    SelectedLanguageTextBlock = textBlock;
            }
        }

        private void LanguageSelectionChanged()
        {
            if (SelectedLanguageTextBlock == null)
                return;

            if (SelectedLanguageTextBlock.Text == Lang.ua)
                Properties.Settings.Default.languageCode = "uk-UA";
            else if (SelectedLanguageTextBlock.Text == Lang.en)
                Properties.Settings.Default.languageCode = "en-US";

            Properties.Settings.Default.Save();
        }
    }
}