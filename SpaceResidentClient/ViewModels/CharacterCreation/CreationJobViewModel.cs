using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SpaceResidentClient.Models.ImagesProcessors;
using SpaceResidentClient.Models.CharacterCreation;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationJobViewModel : ObservableObject
    {
        private readonly CharacterCreationViewModel _characterCreationVM;

        #region props
        [ObservableProperty]
        public ObservableCollection<TextBlock> jobTextBlocks = CreateJobTextBlocksCollection();

        private TextBlock? _selectedJobTextBlock;
        public TextBlock? SelectedJobTextBlock
        {
            get => _selectedJobTextBlock;
            set
            {
                if (value != _selectedJobTextBlock && value != null)
                {
                    _selectedJobTextBlock = value;

                    _characterCreationVM.BgImageSource = CharacterImageProcessor.SetBgImageSource(value.Text);
                }
            }
        }
        #endregion

        public CreationJobViewModel(CharacterCreationViewModel vm)
        {
            _characterCreationVM = vm;
            CreateJobTextBlocksCollection();

            if (SelectedJobTextBlock == null)
                SetSelectedTextBlockFromCollection();
        }

        private static ObservableCollection<TextBlock> CreateJobTextBlocksCollection()
        {
            ObservableCollection<TextBlock> result = [];
            foreach (string str in JobsProcessor.GetJobList)
            {
                result.Add(new() { Text = str });
            }
            return result;
        }

        private void SetSelectedTextBlockFromCollection()
        {
            SelectedJobTextBlock = JobTextBlocks[0];
        }
    }
}