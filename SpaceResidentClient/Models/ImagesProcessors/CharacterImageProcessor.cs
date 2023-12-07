using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace SpaceResidentClient.Models.ImagesProcessors
{
    public class CharacterImageProcessor
    {
        ObservableObject _parentViewModel;

        #region metods
        public void GetAvalibleCharacterImages(char race, bool isFemale)
        {
            ObservableCollection<string> result = [];
            if (race == 'l')
            {
                if (isFemale)
                {
                    string[] values = Directory.GetFiles(@".\Data\UI\Characters\Human\Female\", "*.png");
                    result = [.. values];
                }
                else
                {
                    string[] values = Directory.GetFiles(@".\Data\UI\Characters\Human\Male\", "*.png");
                    result = [.. values];
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].Remove(0, 1).Insert(0, "\\Resources;component");
            }
            if (_parentViewModel is CharacterCreationViewModel characterCreationViewModel)
                characterCreationViewModel.ImageSources = result;
        }

        public void GetAvalibleCharacterImages(char Race)
        {
            throw new NotImplementedException();
        }
        #endregion

        public CharacterImageProcessor(ObservableObject parentViewModel)
        {
            _parentViewModel = parentViewModel;
        }
    }
}