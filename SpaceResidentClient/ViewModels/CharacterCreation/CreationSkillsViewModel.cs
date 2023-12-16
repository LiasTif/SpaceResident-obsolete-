using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models;
using System;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    public partial class CreationSkillsViewModel : ObservableObject
    {
        private readonly CharacterCreationSkillPointsProcessor _characterCreationSkillPointsProcessor = new();

        #region props
        [ObservableProperty]
        public byte points = 60;

        [ObservableProperty]
        public byte linguistics;
        [ObservableProperty]
        public byte naturalistics;
        [ObservableProperty]
        public byte existentialism;
        [ObservableProperty]
        public byte relationships;
        [ObservableProperty]
        public byte logic;
        [ObservableProperty]
        public byte space;
        [ObservableProperty]
        public byte kinetics;
        #endregion

        #region commands
        private void IncreaseCharacteristic(string? characteristic)
        {
            ChangeCharacteristic(characteristic, true);
        }

        private void DecreaseCharacteristic(string? characteristic)
        {
            ChangeCharacteristic(characteristic, false);
        }

        private void ChangeCharacteristic(string? characteristic, bool isIncrease)
        {
            if (characteristic == null)
                return;

            byte value = Convert.ToByte(GetType().GetProperty(characteristic)?.GetValue(this));

            byte oldPoints = Points;
            if (isIncrease)
            {
                Points = _characterCreationSkillPointsProcessor.IncreaseSkill(Points, value);

                if (oldPoints != Points)
                    GetType().GetProperty(characteristic)?.SetValue(this, ++value);
            }
            else
            {
                Points = _characterCreationSkillPointsProcessor.DecreaseSkill(Points, value);

                if (oldPoints != Points)
                    GetType().GetProperty(characteristic)?.SetValue(this, --value);
            }
        }

        public ICommand IncreaseCharacteristicCommand { get; }
        public ICommand DecreaseCharacteristicCommand { get; }
        #endregion

        public CreationSkillsViewModel()
        {
            // set default values to characteristics
            linguistics = naturalistics = existentialism =
                relationships = logic = space = kinetics = 1;

            IncreaseCharacteristicCommand = new RelayCommand<string>(IncreaseCharacteristic);
            DecreaseCharacteristicCommand = new RelayCommand<string>(DecreaseCharacteristic);
        }
    }
}
