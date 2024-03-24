using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Properties;
using System.Collections.Generic;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal class SpawnLocationsProcessor : ObservableObject
    {
        public static List<string> GetLocationTextBlocksCollcetion() => _locationTextBlocksCollcetion;

        private static readonly List<string> _locationTextBlocksCollcetion =
        [
            Lang.locationScienceStation,
            Lang.locationHabitableStation,
            Lang.locationMiningStation,
            Lang.locationPlanet,
        ];
    }
}