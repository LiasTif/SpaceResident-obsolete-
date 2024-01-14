using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using System;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.Models.ImagesProcessors
{
    public class CharacterImageProcessor(ObservableObject parentViewModel)
    {
        readonly ObservableObject _parentViewModel = parentViewModel;

        #region metods
        public string SetBgImageSource(string job)
        {
            if (job == Lang.fleaMarketVendor)
                return "/Resources;component" + "\\Data\\UI\\CharacterJobBGs\\FleaMarket" + ".png";
            else if (job == Lang.unemployed)
                return "/Resources;component" + "\\Data\\UI\\Locations\\Houses\\SpaceStationHome1" + ".png";
            else if (job == Lang.productionWorker)
                return "/Resources;component" + "\\Data\\UI\\CharacterJobBGs\\Fabric" + ".png";
            else if (job == Lang.clerk)
                return "/Resources;component" + "\\Data\\UI\\CharacterJobBGs\\Office" + ".png";
            else
                return String.Empty;
        }

        public void GetAvalibleCharacterImages(char race, bool isFemale)
        {
            if (_parentViewModel is CharacterCreationViewModel characterCreationViewModel)
            {
                characterCreationViewModel.ImageIndex = 1;
                if (isFemale && race == 'l')
                {
                    characterCreationViewModel.ImageCount = 10;
                    characterCreationViewModel.CharacterImagesDirectory = "\\Data\\UI\\Characters\\Human\\Female\\fHuman";
                }
                else if (!isFemale && race == 'l')
                {
                    characterCreationViewModel.ImageCount = 6;
                    characterCreationViewModel.CharacterImagesDirectory = "\\Data\\UI\\Characters\\Human\\Male\\mHuman";
                }
            }
        }

        public void GetAvalibleCharacterImages(char Race)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}