using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SpaceResidentClient.Views.CharacterCreation
{
    /// <summary>
    /// Interaction logic for CharCreationMainView.xaml
    /// </summary>
    public partial class CharCreationMainView : UserControl
    {
        private readonly MediaPlayer _player = new() { Volume = 0.2 };

        public CharCreationMainView()
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