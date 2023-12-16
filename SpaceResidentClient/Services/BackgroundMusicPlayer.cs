using System.Windows;
using System;
using System.Windows.Media;

namespace SpaceResidentClient.Services
{
    static class BackgroundMusicPlayer
    {
        public static MediaPlayer Player = new();

        public static void LoadMusic(string path)
        {
            Player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
            Player.Open(new Uri(path, UriKind.Relative));
            Player.Play();
        }
    }
}