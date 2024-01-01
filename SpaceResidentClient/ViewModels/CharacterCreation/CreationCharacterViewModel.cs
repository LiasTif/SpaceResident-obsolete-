using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Properties;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationCharacterViewModel : ObservableObject
    {
        private readonly CharacterCreationViewModel _characterCreationViewModel;

        #region props
        #pragma warning disable CS8603 // Possible null reference return.
        public static string Name
        {
            get => CharacterCreationViewModel.MainCharacter.Name;
            set => CharacterCreationViewModel.MainCharacter.Name = value;
        }
        public static string Surname
        {
            get => CharacterCreationViewModel.MainCharacter.Surname;
            set => CharacterCreationViewModel.MainCharacter.Surname = value;
        }
        public int Age
        {
            get => CharacterCreationViewModel.MainCharacter.Age;
            set
            {
                CharacterCreationViewModel.MainCharacter.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public bool IsFemale
        {
            get => CharacterCreationViewModel.MainCharacter.IsFemale;
            set
            {
                CharacterCreationViewModel.MainCharacter.IsFemale = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        #pragma warning restore CS8603 // Possible null reference return.

        private string _race = Lang.human;
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
        private void ChangeGender() => IsFemale = !IsFemale;
        private void MinusAge()
        {
            if (Age > 20)
                Age -= 1;
        }
        private void PlusAge()
        {
            if (Age < 30)
                Age += 1;
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
            if (Race == Lang.vun_ti)
                _characterCreationViewModel.ImageProcessor.GetAvalibleCharacterImages('t');
            else if (Race == Lang.vun_flant)
                _characterCreationViewModel.ImageProcessor.GetAvalibleCharacterImages('f');
            else if (Race == Lang.human)
                race = 'l';
            else if (Race == Lang.vun_mis_ak)
                race = 'm';

            _characterCreationViewModel.ImageProcessor.GetAvalibleCharacterImages(race,
                IsFemale);
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