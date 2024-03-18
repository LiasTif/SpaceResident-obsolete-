using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.CharacterCreation;
using SpaceResidentClient.Models.CharacterCreation.Interfaces;
using SpaceResidentClient.Services.UISounds;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    internal partial class SkillPointsSwitcherViewModel : ObservableObject
    {
        private readonly CharacterCreationSkillPointsProcessor _characterCreationSkillPointsProcessor = new();
        private readonly ICharCreationSkillsMain _charCreationSkillsMain;

        [ObservableProperty]
        public byte skill = 1;
        public string SkillName { get; private set; }

        public SkillPointsSwitcherViewModel(ICharCreationSkillsMain charCreationSkillsMain, string skillName)
        {
            _charCreationSkillsMain = charCreationSkillsMain;
            SkillName = skillName;

            IncreaseCharacteristicCommand = new RelayCommand<string>(IncreaseCharacteristic);
            DecreaseCharacteristicCommand = new RelayCommand<string>(DecreaseCharacteristic);
        }

        #region commands
        public ICommand IncreaseCharacteristicCommand { get; }
        public ICommand DecreaseCharacteristicCommand { get; }
        #endregion

        #region methods
        private void IncreaseCharacteristic(string? characteristic) => ChangeCharacteristic(true);
        private void DecreaseCharacteristic(string? characteristic) => ChangeCharacteristic(false);

        private void ChangeCharacteristic(bool isIncrease)
        {
            int oldPoints = _charCreationSkillsMain.Points;

            if (isIncrease)
                _charCreationSkillsMain.Points = _characterCreationSkillPointsProcessor.IncreaseSkill(_charCreationSkillsMain.Points, Skill);
            else
                _charCreationSkillsMain.Points = _characterCreationSkillPointsProcessor.DecreaseSkill(_charCreationSkillsMain.Points, Skill);

            if (oldPoints != _charCreationSkillsMain.Points)
            {
                Skill = (byte)(isIncrease ? Skill + 1 : Skill - 1);
            }

            ArrowButtonClickPlayer.LoadClickPlayer();
        }
        #endregion
    }
}