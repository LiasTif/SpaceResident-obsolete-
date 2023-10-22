using System.Windows.Controls;
using System.Windows.Media;
using System;

namespace SpaceResidentClient.Views.MainMenu
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        private MediaPlayer _player = new();

        public MainMenuView()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _player.Open(new Uri("Data/sounds/UI/Button Hover.wav", UriKind.Relative));
            _player.Volume = 0.2;
            _player.Play();
        }
    }
}