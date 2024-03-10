using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using System;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.Models.ImagesProcessors
{
    internal class CharacterImageProcessor(ObservableObject parentViewModel)
    {
        private readonly ObservableObject _parentViewModel = parentViewModel;

        #region metods
        internal static string SetBgImageSource(string job)
        {
            string uri = "/Resources;component\\Data\\UI\\";

            if (job == Lang.fleaMarketVendor)
                uri += "CharacterJobBGs\\FleaMarket";
            else if (job == Lang.unemployed)
                uri += "Locations\\Houses\\SpaceStationHome1";
            else if (job == Lang.productionWorker)
                uri += "CharacterJobBGs\\Fabric";
            else if (job == Lang.clerk)
                uri += "CharacterJobBGs\\Office";

            return uri += ".png";
        }

        internal void GetAvalibleCharacterImages(char race, bool isFemale)
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

        internal void GetAvalibleCharacterImages(char Race)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}