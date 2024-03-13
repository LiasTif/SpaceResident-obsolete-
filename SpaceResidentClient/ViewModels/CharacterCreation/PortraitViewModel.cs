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
        public readonly CharacterImageProcessor ImageProcessor; 

        public PortraitViewModel()
        {
            BgImageSource = CharacterImageProcessor.SetBgImageSource(Lang.unemployed);
            ImageProcessor = new CharacterImageProcessor(this);
        }

        [ObservableProperty]
        public string imageSource = String.Empty;
        [ObservableProperty]
        public string? bgImageSource;

        #region props
        private int ImageIndex { get; set; } = 0;
        private int ImageCount { get; set; }

        private string? _characterImagesDirectory;
        public string? CharacterImagesDirectory
        {
            get => _characterImagesDirectory;
            set
            {
                if (_characterImagesDirectory != value)
                {
                    _characterImagesDirectory = value;
                    ImageSource = "/Resources;component" + _characterImagesDirectory + ImageIndex + ".png";
                }
            }
        }
        #endregion

        #region commands
        public ICommand NextImageCommand { get => new RelayCommand(NextImage); }
        public ICommand PreviousImageCommand { get => new RelayCommand(PreviousImage); }
        #endregion

        private void NextImage()
        {
            // set next image or set first image if it`s end of images collection
            ImageIndex = ImageIndex >= ImageCount - 1 ? 1 : ImageIndex + 1;
            LoadNewImage();
        }
        private void PreviousImage()
        {
            // set previous image or set last image if it`s start of images collection
            ImageIndex = ImageIndex <= 1 ? ImageCount - 1 : ImageIndex - 1;
            LoadNewImage();
        }

        private void LoadNewImage()
        {
            ImageSource = "/Resources;component" + CharacterImagesDirectory + ImageIndex + ".png";
            ArrowButtonClickPlayer.LoadClickPlayer();
        }

        public void SetPortraits(int count, String uri)
        {
            ImageIndex = 1;
            ImageCount = count;
            ImageSource += uri;
        }
    }
}