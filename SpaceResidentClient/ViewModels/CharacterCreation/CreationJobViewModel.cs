using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SpaceResidentClient.Models.ImagesProcessors;
using SpaceResidentClient.Models.CharacterCreation;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CreationJobViewModel : ObservableObject
    {
        private readonly PortraitViewModel? _portraitVM;

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

                    if (_portraitVM != null)
                        _portraitVM.BgImageSource = CharacterImageProcessor.SetBgImageSource(value.Text);
                }
            }
        }
        #endregion

        public CreationJobViewModel(PortraitViewModel portraitVM)
        {
            _portraitVM = portraitVM;
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