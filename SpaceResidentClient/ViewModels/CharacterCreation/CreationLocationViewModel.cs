using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Models.CharacterCreation;
using SpaceResidentClient.Properties;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    internal partial class CreationLocationViewModel : ObservableObject
    {
        public CreationLocationViewModel()
        {
            SetSelectedLocationTextBlockFromCollection();
        }

        #region props
        [ObservableProperty]
        public ObservableCollection<TextBlock> locationTextBlocks = SpawnLocationsProcessor.GetLocationTextBlocksCollcetion;
        [ObservableProperty]
        public TextBlock selectedLocationTextBlock = new();
        #endregion

        private void SetSelectedLocationTextBlockFromCollection()
        {
            if (LocationTextBlocks != null && LocationTextBlocks.Count > 0)
                SelectedLocationTextBlock = LocationTextBlocks[0];
        }
    }
}