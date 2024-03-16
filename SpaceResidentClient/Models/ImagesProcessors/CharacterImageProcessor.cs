using SpaceResidentClient.ViewModels.CharacterCreation;
using System;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.Models.ImagesProcessors
{
    internal class CharacterImageProcessor(PortraitViewModel portraitViewModel)
    {
        private readonly PortraitViewModel _portraitViewModel = portraitViewModel;

        #region metods
        private void SetSourceToPortraits(int count, String uri) => _portraitViewModel.SetPortraits(count, uri);

        public static string SetBgImageSource(string job)
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

        public void GetAvalibleCharacterImages(char race, bool isFemale)
        {
            if (race == 'l')
            {
                if (isFemale)
                    SetSourceToPortraits(10, "\\Data\\UI\\Characters\\Vun-Lain\\Female\\fHuman");
                else
                    SetSourceToPortraits(6, "\\Data\\UI\\Characters\\Vun-Lain\\Male\\mHuman");
            }
        }

        public void GetAvalibleCharacterImages(char Race)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}