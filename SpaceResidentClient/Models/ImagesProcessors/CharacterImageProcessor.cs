using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using System;
using SpaceResidentClient.Properties;
using System.Diagnostics;

namespace SpaceResidentClient.Models.ImagesProcessors
{
    public class CharacterImageProcessor(ObservableObject parentViewModel)
    {
        readonly ObservableObject _parentViewModel = parentViewModel;

        #region metods
        public string SetBgImageSource(string job)
        {
            string uri = "/Resources;component";

            if (job == Lang.fleaMarketVendor)
                uri += "\\Data\\UI\\CharacterJobBGs\\FleaMarket";
            else if (job == Lang.unemployed)
                uri += "\\Data\\UI\\Locations\\Houses\\SpaceStationHome1";
            else if (job == Lang.productionWorker)
                uri += "\\Data\\UI\\CharacterJobBGs\\Fabric";
            else if (job == Lang.clerk)
                uri += "\\Data\\UI\\CharacterJobBGs\\Office";

            return uri += ".png";
        }

        public void GetAvalibleCharacterImages(char race, bool isFemale)
        {
            if (_parentViewModel is CharacterCreationViewModel characterCreationVM)
            {
                characterCreationVM.ImageIndex = 1;

                if (race == 'l')
                {
                    if (isFemale)
                        SetSourceToPortraits(characterCreationVM, 10, "\\Data\\UI\\Characters\\Vun-Lain\\Female\\fHuman");
                    else
                        SetSourceToPortraits(characterCreationVM, 6, "\\Data\\UI\\Characters\\Vun-Lain\\Male\\mHuman");
                }
            }
        }

        private static void SetSourceToPortraits(CharacterCreationViewModel characterCreationVM, int count, string uri)
        {
            characterCreationVM.ImageCount = count;
            characterCreationVM.CharacterImagesDirectory = uri;
        }

        public void GetAvalibleCharacterImages(char Race)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}