using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationJobViewModel : ObservableObject
    {
        private readonly CharacterCreationViewModel _characterCreationViewModel;

        #region props
        [ObservableProperty]
        public ObservableCollection<TextBlock> jobTextBlocks = [];

        private TextBlock? _selectedJobTextBlock;
        public TextBlock? SelectedJobTextBlock
        {
            get => _selectedJobTextBlock;
            set
            {
                if (value != _selectedJobTextBlock && value != null)
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
            CreateJobTextBlocksCollection();

            if (SelectedJobTextBlock == null)
                SetSelectedTextBlockFromCollection();
        }

        private void CreateJobTextBlocksCollection()
        {
            JobTextBlocks =
            [
                new() { Text = Lang.unemployed },
                new() { Text = Lang.clerk },
                new() { Text = Lang.fleaMarketVendor },
                new() { Text = Lang.productionWorker }
            ];
        }

        private void SetSelectedTextBlockFromCollection()
        {
            SelectedJobTextBlock = JobTextBlocks[0];
        }
    }
}