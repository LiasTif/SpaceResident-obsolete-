using System;
using System.Windows;
using System.Windows.Media;

namespace SpaceResidentClient.Services.UISounds
{
    class ArrowButtonClickPlayer
    {
        public static MediaPlayer ClickPlayer = new();

        public static void LoadClickPlayer()
        {
            ClickPlayer.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
            ClickPlayer.Volume = 0.5;
            ClickPlayer.Open(new Uri("Data/sounds/UI/ButtonHoverMinPlus.wav", UriKind.Relative));
            ClickPlayer.Play();
        }
    }
}