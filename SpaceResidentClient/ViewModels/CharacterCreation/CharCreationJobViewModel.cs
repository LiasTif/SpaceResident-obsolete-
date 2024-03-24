using System.Windows.Controls;
using SpaceResidentClient.Models.CharacterCreation;
using SpaceResidentClient.Models;
using SpaceResidentClient.Properties;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    partial class CharCreationJobViewModel : ComboBoxesRealization
    {
        private readonly PortraitViewModel _portraitVM;
        public CharCreationJobViewModel(PortraitViewModel portraitVM)
        {
            _portraitVM = portraitVM;
            UpdateTBContent(JobsProcessor.GetJobList());
            UpdateSelectedTB(Lang.unemployed);
        }

        #region props
        private TextBlock? selectedTextBlock;
        public override TextBlock? SelectedTextBlock
        {
            get => selectedTextBlock;
            set
            {
                if (value != selectedTextBlock && value != null)
                {
                    selectedTextBlock = value;
                    _portraitVM.BgImageSource = CharacterImageProcessor.SetBgImageSource(value.Text);
                }
            }
        }
        #endregion
    }
}