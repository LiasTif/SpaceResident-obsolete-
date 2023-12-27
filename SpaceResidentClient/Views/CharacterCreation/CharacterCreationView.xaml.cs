using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SpaceResidentClient.Views.CharacterCreation
{
    /// <summary>
    /// Interaction logic for CharacterCreationView.xaml
    /// </summary>
    public partial class CharacterCreationView : UserControl
    {
        private readonly MediaPlayer _player = new() { Volume = 0.2 };

        public CharacterCreationView()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            _player.Open(new Uri("Data/sounds/UI/ButtonHover.wav", UriKind.Relative));
            _player.Play();
        }
    }
}