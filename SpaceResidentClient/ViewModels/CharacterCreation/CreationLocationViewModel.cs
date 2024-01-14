using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Properties;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    public partial class CreationLocationViewModel : ObservableObject
    {
        public CreationLocationViewModel()
        {
            FillLocationTextBlocksCollection();
            SetSelectedLocationTextBlockFromCollection();
        }

        #region props
        [ObservableProperty]
        public ObservableCollection<TextBlock> locationTextBlocks = [];
        [ObservableProperty]
        public TextBlock selectedLocationTextBlock = new();
        #endregion

        private void FillLocationTextBlocksCollection()
        {
            LocationTextBlocks =
            [
                new() { Text = Lang.locationScienceStation },
                new() { Text = Lang.locationHabitableStation },
                new() { Text = Lang.locationMiningStation },
                new() { Text = Lang.locationPlanet },
            ];
        }

        private void SetSelectedLocationTextBlockFromCollection()
        {
            if (LocationTextBlocks != null && LocationTextBlocks.Count > 0)
            {
                SelectedLocationTextBlock = LocationTextBlocks[0];
            }
        }
    }
}