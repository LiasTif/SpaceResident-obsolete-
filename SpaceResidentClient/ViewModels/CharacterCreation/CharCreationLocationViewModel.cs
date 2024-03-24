using SpaceResidentClient.Models;
using SpaceResidentClient.Models.CharacterCreation;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    internal partial class CharCreationLocationViewModel : ComboBoxesRealization
    {
        public CharCreationLocationViewModel()
        {
            UpdateTBContent(SpawnLocationsProcessor.GetLocationTextBlocksCollcetion());
            UpdateSelectedTB(Lang.locationPlanet);
        }
    }
}