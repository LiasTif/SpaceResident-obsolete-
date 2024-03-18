using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Models.CharacterCreation.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    internal partial class CharCreationSkillsViewModel : ObservableObject, ICharCreationSkillsMain
    {
        public CharCreationSkillsViewModel()
        {
            CreateSkillPointSwithers();
        }

        #region props
        [ObservableProperty]
        public int points = 60;
        [ObservableProperty]
        public ObservableCollection<SkillPointsSwitcherViewModel> skillPointsSwitcherViewModels = [];
        #endregion

        private void CreateSkillPointSwithers()
        {
            foreach (string skillName in SkillNames)
            {
                SkillPointsSwitcherViewModels.Add(new SkillPointsSwitcherViewModel(this, skillName));
            }
        }

        private readonly List<string> SkillNames =
        [
            "Linguistics",
            "Naturalistics",
            "Existentialism",
            "Relationships",
            "Logic",
            "Space",
            "Kinetics",
        ];
    }
}
