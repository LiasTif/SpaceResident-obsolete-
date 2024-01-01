using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationJobViewModel : ObservableObject
    {
        private CharacterCreationViewModel _characterCreationViewModel;

        #region props
        [ObservableProperty]
        public ObservableCollection<TextBlock> jobTextBlocks;

        private TextBlock _selectedJobTextBlock = new();

        public TextBlock SelectedJobTextBlock
        {
            get => _selectedJobTextBlock;
            set
            {
                if (value != _selectedJobTextBlock)
                {
                    _selectedJobTextBlock = value;
                    _characterCreationViewModel.BgImageSource =
                        _characterCreationViewModel.ImageProcessor.SetBgImageSource(value.Text);
                }
            }
        }
        #endregion

        public CreationJobViewModel(CharacterCreationViewModel characterCreationViewModel)
        {
            _characterCreationViewModel = characterCreationViewModel;
            JobTextBlocks = CreateJobTextBlocks();
        }

        private ObservableCollection<TextBlock> CreateJobTextBlocks()
        {
            return
            [
                new() { Text = Lang.clerk },
                new() { Text = Lang.fleaMarketVendor },
                new() { Text = Lang.productionWorker },
                new() { Text = Lang.unemployed }
            ];
        }
    }
}