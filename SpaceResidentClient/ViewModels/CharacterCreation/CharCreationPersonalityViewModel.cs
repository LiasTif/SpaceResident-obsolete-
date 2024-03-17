using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Services.UISounds;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharCreationPersonalityViewModel : ObservableObject
    {
        private readonly PortraitViewModel _portraitVM;

        public CharCreationPersonalityViewModel(PortraitViewModel portraitVM)
        {
            _portraitVM = portraitVM;
            RaceOrGenderHasChanged();
        }

        #region props
        public static string Name
        {
            get => CharCreationMainViewModel.MainCharacter.Name;
            set => CharCreationMainViewModel.MainCharacter.Name = value;
        }
        public static string Surname
        {
            get => CharCreationMainViewModel.MainCharacter.Surname;
            set => CharCreationMainViewModel.MainCharacter.Surname = value;
        }
        public int Age
        {
            get => CharCreationMainViewModel.MainCharacter.Age;
            set
            {
                CharCreationMainViewModel.MainCharacter.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public bool IsFemale
        {
            get => CharCreationMainViewModel.MainCharacter.IsFemale;
            set
            {
                CharCreationMainViewModel.MainCharacter.IsFemale = value;
                OnPropertyChanged(nameof(IsFemale));
                RaceOrGenderHasChanged();
            }
        }
        public char Race
        {
            get => CharCreationMainViewModel.MainCharacter.Race;
            set
            {
                CharCreationMainViewModel.MainCharacter.Race = value;
                OnPropertyChanged(nameof(Race));
                RaceOrGenderHasChanged();
            }
        }
        #endregion

        #region commands
        public ICommand ChangeGenderCommand { get => new RelayCommand(ChangeGender); }
        public ICommand MinusAgeCommand { get => new RelayCommand(MinusAge); }
        public ICommand PlusAgeCommand { get => new RelayCommand(PlusAge); }
        #endregion

        #region methods
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

        private void RaceOrGenderHasChanged()
        {
            // vun-ti (t) and vun_flant (f) don`t have a gender and go to GetAvalibleCharacterImages metod immedeatly
            if (Race == 't' || Race == 'f')
                _portraitVM.ImageProcessor.GetAvalibleCharacterImages(Race);
            else
                _portraitVM.ImageProcessor.GetAvalibleCharacterImages(Race, IsFemale);
        }
        #endregion
    }
}