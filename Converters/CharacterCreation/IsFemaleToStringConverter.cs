using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters.CharacterCreation
{
    public class IsFemaleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Properties.Lang.female;
            else
                return Properties.Lang.male;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
