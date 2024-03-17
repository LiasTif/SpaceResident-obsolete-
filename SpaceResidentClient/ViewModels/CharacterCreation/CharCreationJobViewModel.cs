using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SpaceResidentClient.Models.CharacterCreation;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharCreationJobViewModel(PortraitViewModel portraitVM) : ObservableObject
    {
        private readonly PortraitViewModel _portraitVM = portraitVM;

        #region props
        private TextBlock? _selectedJobTextBlock;
        public TextBlock? SelectedJobTextBlock
        {
            get => _selectedJobTextBlock;
            set
            {
                if (value != _selectedJobTextBlock && value != null)
                {
                    _selectedJobTextBlock = value;
                    _portraitVM.BgImageSource = CharacterImageProcessor.SetBgImageSource(value.Text);
                }
            }
        }
        [ObservableProperty]
        public ObservableCollection<TextBlock> jobTextBlocks = CreateJobTextBlocksCollection();
        #endregion

        /// <summary>
        /// Generate text blocks based on job list
        /// </summary>
        /// <returns>Text blocks collection</returns>
        private static ObservableCollection<TextBlock> CreateJobTextBlocksCollection()
        {
            ObservableCollection<TextBlock> result = [];
            foreach (string str in JobsProcessor.GetJobList)
            {
                result.Add(new() { Text = str });
            }
            return result;
        }
    }
}