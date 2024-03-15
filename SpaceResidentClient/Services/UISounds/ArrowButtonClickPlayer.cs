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
            ClickPlayer.Open(new Uri("Data/sounds/UI/ButtonHoverMinPlus.mp3", UriKind.Relative));
            ClickPlayer.Play();
        }
    }
}