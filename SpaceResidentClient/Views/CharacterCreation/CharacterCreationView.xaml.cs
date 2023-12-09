using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceResidentClient.Views.CharacterCreation
{
    /// <summary>
    /// Interaction logic for CharacterCreationView.xaml
    /// </summary>
    public partial class CharacterCreationView : UserControl
    {
        private MediaPlayer _player = new() { Volume = 0.2 };

        public CharacterCreationView()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _player.Open(new Uri("Data/sounds/UI/Button Hover.wav", UriKind.Relative));
            _player.Play();
        }
    }
}
