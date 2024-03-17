using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Models.CharacterCreation;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    internal partial class CharCreationLocationViewModel : ObservableObject
    {
        public CharCreationLocationViewModel()
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