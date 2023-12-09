using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    public partial class CreationSkillsViewModel : ObservableObject
    {
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
            byte value = Convert.ToByte(GetType().GetProperty(characteristic)
                                                 .GetValue(this));

            if (Points > 0)
            {
                if (value < 5)
                {
                    Points--;
                }
                else if (value < 8 && Points > 1)
                {
                    Points -= 2;
                }
                else if (value < 10 && Points > 2)
                {
                    Points -= 3;
                }
                else if (value < 12 && Points > 3)
                {
                    Points -= 4;
                }
                else if (value < 14 && Points > 4)
                {
                    Points -= 5;
                }
                else if (value == 14 && Points > 5)
                {
                    Points -= 6;
                }
                else if (value == 15 && Points > 6)
                {
                    Points -= 7;
                }
                else if (value == 16 && Points > 7)
                {
                    Points -= 8;
                }
                else if (value == 17 && Points > 8)
                {
                    Points -= 9;
                }
                else if (value == 18 && Points > 9)
                {
                    Points -= 10;
                }
                else
                {
                    return;
                }
                GetType().GetProperty(characteristic)
                         .SetValue(this, ++value);
            }
        }
        private void DecreaseCharacteristic(string? characteristic)
        {
            byte value = Convert.ToByte(GetType().GetProperty(characteristic)
                                                 .GetValue(this));

            if (value > 1)
            {
                if (value <= 5)
                {
                    Points++;
                }
                else if (value <= 8)
                {
                    Points += 2;
                }
                else if (value <= 10)
                {
                    Points += 3;
                }
                else if (value <= 12)
                {
                    Points += 4;
                }
                else if (value <= 14)
                {
                    Points += 5;
                }
                else if (value == 15)
                {
                    Points += 6;
                }
                else if (value == 16)
                {
                    Points += 7;
                }
                else if (value == 17)
                {
                    Points += 8;
                }
                else if (value == 18)
                {
                    Points += 9;
                }
                else if (value == 19)
                {
                    Points += 10;
                }
                else
                {
                    return;
                }
                GetType().GetProperty(characteristic)
                         .SetValue(this, --value);
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
