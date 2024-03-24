using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using SpaceResidentClient.Properties;
using SpaceResidentClient.Models;
using System.Collections.Generic;

namespace SpaceResidentClient.ViewModels.MainMenu.Settings
{
    partial class GameSettingsViewModel : ComboBoxesRealization
    {
        public GameSettingsViewModel()
        {
            UpdateTBContent(Languages);
            UpdateSelectedTB();
        }

        #region commands
        public ICommand LanguageSelectionChangedCommand { get => new RelayCommand(LanguageSelectionChanged); }
        #endregion

        private void UpdateSelectedTB()
        {
            string languageCode = Properties.Settings.Default.languageCode;

            if (languageCode == "uk-UA")
                base.UpdateSelectedTB(Lang.ua);
            else if (languageCode == "en-US")
                base.UpdateSelectedTB(Lang.en);
        }

        private void LanguageSelectionChanged()
        {
            if (SelectedTextBlock == null)
                return;

            if (SelectedTextBlock.Text == Lang.ua)
                Properties.Settings.Default.languageCode = "uk-UA";
            else if (SelectedTextBlock.Text == Lang.en)
                Properties.Settings.Default.languageCode = "en-US";

            Properties.Settings.Default.Save();
        }

        private readonly List<string> Languages =
        [
            Lang.ua,
            Lang.en,
        ];
    }
}