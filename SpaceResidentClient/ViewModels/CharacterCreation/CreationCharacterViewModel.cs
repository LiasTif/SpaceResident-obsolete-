using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Services.UISounds;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationCharacterViewModel : ObservableObject
    {
        private readonly CharacterCreationViewModel _characterCreationViewModel;

        #region props
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
                OnPropertyChanged(nameof(IsFemale));
                RaceOrGenderHasChanged();
            }
        }
        public char Race
        {
            get => CharacterCreationViewModel.MainCharacter.Race;
            set
            {
                CharacterCreationViewModel.MainCharacter.Race = value;
                OnPropertyChanged(nameof(Race));
                RaceOrGenderHasChanged();
            }
        }
        #endregion

        #region commands
        private void ChangeGender()
        {
            IsFemale = !IsFemale;
            ArrowButtonClickPlayer.LoadClickPlayer();
        }
        private void MinusAge()
        {
            if (Age > 20)
            {
                Age -= 1;
                ArrowButtonClickPlayer.LoadClickPlayer();
            }
        }
        private void PlusAge()
        {
            if (Age < 30)
            {
                Age += 1;
                ArrowButtonClickPlayer.LoadClickPlayer();
            }
        }
        public ICommand ChangeGenderCommand { get => new RelayCommand(ChangeGender); }
        public ICommand MinusAgeCommand { get => new RelayCommand(MinusAge); }
        public ICommand PlusAgeCommand { get => new RelayCommand(PlusAge); }
        #endregion

        #region methods
        private void RaceOrGenderHasChanged()
        {
            // vun-ti (t) and vun_flant (f) don`t have a gender and go to GetAvalibleCharacterImages metod immedeatly
            if (Race == 't' || Race == 'f')
                _characterCreationViewModel.CharacterImageProcessor.GetAvalibleCharacterImages(Race);
            else
                _characterCreationViewModel.ImageProcessor.GetAvalibleCharacterImages(Race, IsFemale);
        }
        #endregion

        public CreationCharacterViewModel(CharacterCreationViewModel characterCreationViewModel)
        {
            _characterCreationViewModel = characterCreationViewModel;
            RaceOrGenderHasChanged();
        }
    }
}