using CommunityToolkit.Mvvm.ComponentModel;

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

        private string _gender = "Female";
        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                    RaceOrGenderChanged();
                }
            }
        }

        private string _race = "Human";
        public string Race
        {
            get => _race;
            set
            {
                if (_race != value)
                {
                    _race = value;
                    OnPropertyChanged(nameof(Race));
                    RaceOrGenderChanged();
                }
            }
        }
        #endregion

        private void RaceOrGenderChanged()
        {
            char race = '0';
            if (Race == "vun-ti")
                _characterCreationViewModel._imageProcessor.GetAvalibleCharacterImages('t');
            else if (Race == "vun-flant")
                _characterCreationViewModel._imageProcessor.GetAvalibleCharacterImages('f');
            else if (Race == "Human")
                race = 'l';
            else if (Race == "vun-mis'ak")
                race = 'm';

            bool isFemale = Gender == "Female";

            _characterCreationViewModel._imageProcessor.GetAvalibleCharacterImages(race, isFemale);
        }

        public CreationCharacterViewModel(CharacterCreationViewModel characterCreationViewModel)
        {
            _characterCreationViewModel = characterCreationViewModel;
            RaceOrGenderChanged();
        }
    }
}