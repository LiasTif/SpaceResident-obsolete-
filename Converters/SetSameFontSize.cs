using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Converters
{
    public class SetSameFontSize : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is TextBlock textBlock ? textBlock.FontSize : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}