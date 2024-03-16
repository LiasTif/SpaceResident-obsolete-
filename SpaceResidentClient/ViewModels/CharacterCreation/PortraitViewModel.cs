using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceResidentClient.Models.ImagesProcessors;
using SpaceResidentClient.Properties;
using SpaceResidentClient.Services.UISounds;
using System;
using System.Windows.Input;

namespace SpaceResidentClient.ViewModels.CharacterCreation
{
    internal partial class PortraitViewModel : ObservableObject
    {
        public PortraitViewModel()
        {
            ImageProcessor = new CharacterImageProcessor(this);
        }

        #region props
        [ObservableProperty]
        private string bgImageSource = CharacterImageProcessor.SetBgImageSource(Lang.unemployed);
        private int ImageIndex { get; set; } = 0;
        private int ImageCount { get; set; }

        public CharacterImageProcessor ImageProcessor { get; private set; }
        [ObservableProperty]
        public string fullImageSource = String.Empty;
        
        private string _characterImagesDirectory = String.Empty;
        public string CharacterImagesDirectory
        {
            get => _characterImagesDirectory;
            set
            {
                if (_characterImagesDirectory != value)
                {
                    _characterImagesDirectory = value;
                    FullImageSource = "/Resources;component" + _characterImagesDirectory + ImageIndex + ".png";
                }
            }
        }
        #endregion

        #region commands
        public ICommand NextImageCommand { get => new RelayCommand(NextImage); }
        public ICommand PreviousImageCommand { get => new RelayCommand(PreviousImage); }
        #endregion

        private void NextImage() => SwitchImage(true);
        private void PreviousImage() => SwitchImage(false);

        private void SwitchImage(bool isNext)
        {
            if (isNext)
            {
                // set next image or set first image if it`s end of images collection
                ImageIndex = ImageIndex >= ImageCount - 1 ? 1 : ++ImageIndex;
            }
            else
            {
                // set previous image or set last image if it`s start of images collection
                ImageIndex = ImageIndex <= 1 ? ImageCount - 1 : --ImageIndex;
            }

            LoadNewImage();
        }

        private void LoadNewImage()
        {
            FullImageSource = "/Resources;component" + CharacterImagesDirectory + ImageIndex + ".png";
            ArrowButtonClickPlayer.LoadClickPlayer();
        }

        public void SetPortraits(int count, String uri)
        {
            ImageIndex = 1;
            ImageCount = count;
            CharacterImagesDirectory = uri;
        }
    }
}