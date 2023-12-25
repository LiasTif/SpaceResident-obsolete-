using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationCharacterViewModel : ObservableObject
    {
        readonly CharacterCreationViewModel _characterCreationViewModel;

        #region props
        [ObservableProperty]
        public string name = string.Empty;
        [ObservableProperty]
        public string surname = string.Empty;
        [ObservableProperty]
        public string age = "21";

        private string _gender = Properties.Lang.female;
        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                    RaceOrGenderHasChanged();
                }
            }
        }

        private string _race = Properties.Lang.human;
        public string Race
        {
            get => _race;
            set
            {
                if (_race != value)
                {
                    _race = value;
                    OnPropertyChanged(nameof(Race));
                    RaceOrGenderHasChanged();
                }
            }
        }
        #endregion

        #region commands
        private void ChangeGender()
        {
            var male = Properties.Lang.male;
            var female = Properties.Lang.female;
            Gender = Gender == male ? female : male;
        }
        private void MinusAge()
        {
            if (Int32.Parse(Age) > 20)
                Age = (Int32.Parse(Age) - 1).ToString();
        }
        private void PlusAge()
        {
            if (Int32.Parse(Age) < 30)
                Age = (Int32.Parse(Age) + 1).ToString();
        }
        public ICommand ChangeGenderCommand { get; }
        public ICommand MinusAgeCommand { get; }
        public ICommand PlusAgeCommand { get; }
        #endregion

        #region methods
        private void RaceOrGenderHasChanged()
        {
            char race = '0';
            // vun-ti and vun_flant don`t have a gender and go to GetAvalibleCharacterImages metod immedeatly
            if (Race == Properties.Lang.vun_ti)
                _characterCreationViewModel.ImageProcessor.GetAvalibleCharacterImages('t');
            else if (Race == Properties.Lang.vun_flant)
                _characterCreationViewModel.ImageProcessor.GetAvalibleCharacterImages('f');
            else if (Race == Properties.Lang.human)
                race = 'l';
            else if (Race == Properties.Lang.vun_mis_ak)
                race = 'm';

            _characterCreationViewModel.ImageProcessor.GetAvalibleCharacterImages(race,
                Gender == Properties.Lang.female);
        }
        #endregion

        public CreationCharacterViewModel(CharacterCreationViewModel characterCreationViewModel)
        {
            ChangeGenderCommand = new RelayCommand(ChangeGender);
            MinusAgeCommand = new RelayCommand(MinusAge);
            PlusAgeCommand = new RelayCommand(PlusAge);

            _characterCreationViewModel = characterCreationViewModel;
            RaceOrGenderHasChanged();
        }
    }
}