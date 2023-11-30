using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Converters.MainMenu
{
    public class ChangeScreenModeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is ComboBox comboBox && values[1] is Window window)
            {
                switch (comboBox.SelectedIndex)
                {
                    // fullscreen
                    case 0:
                        window.WindowStyle = WindowStyle.ThreeDBorderWindow;
                        window.WindowState = WindowState.Maximized;
                        break;
                    // windowed
                    case 1:
                        window.WindowStyle = WindowStyle.ThreeDBorderWindow;
                        window.WindowState = WindowState.Normal;
                        break;
                    // borderless window
                    default:
                        window.WindowStyle = WindowStyle.None;
                        window.WindowState = WindowState.Normal;
                        break;
                }
            }
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
