using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Properties;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal class SpawnLocationsProcessor : ObservableObject
    {
        public static ObservableCollection<TextBlock> GetLocationTextBlocksCollcetion => _locationTextBlocksCollcetion;

        private static ObservableCollection<TextBlock> _locationTextBlocksCollcetion =
        [
            new() { Text = Lang.locationScienceStation },
            new() { Text = Lang.locationHabitableStation },
            new() { Text = Lang.locationMiningStation },
            new() { Text = Lang.locationPlanet },
        ];
    }
}