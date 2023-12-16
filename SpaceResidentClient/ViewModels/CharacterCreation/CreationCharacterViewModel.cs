using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationCharacterViewModel : ObservableObject
    {
        CharacterCreationViewModel _characterCreationViewModel;

        #region props
        [ObservableProperty]
        public string name = string.Empty;
        [ObservableProperty]
        public string surname = string.Empty;
        [ObservableProperty]
        public string age = "20";

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
        public ICommand ChangeGenderCommand { get; }
        #endregion

        private void RaceOrGenderHasChanged()
        {
            char race = '0';
            // vun-ti and vun_flant don`t have a gender and go to GetAvalibleCharacterImages metod immedeatly
            if (Race == Properties.Lang.vun_ti)
                _characterCreationViewModel._imageProcessor.GetAvalibleCharacterImages('t');
            else if (Race == Properties.Lang.vun_flant)
                _characterCreationViewModel._imageProcessor.GetAvalibleCharacterImages('f');
            else if (Race == Properties.Lang.human)
                race = 'l';
            else if (Race == Properties.Lang.vun_mis_ak)
                race = 'm';

            _characterCreationViewModel._imageProcessor.GetAvalibleCharacterImages(race,
                Gender == Properties.Lang.female);
        }

        public CreationCharacterViewModel(CharacterCreationViewModel characterCreationViewModel)
        {
            ChangeGenderCommand = new RelayCommand(ChangeGender);
            _characterCreationViewModel = characterCreationViewModel;
            RaceOrGenderHasChanged();
        }
    }
}