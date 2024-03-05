using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters.Client.CharacterCreation
{
    public class IsFemaleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool)
                throw new ArgumentException("Argument must be a bool type\nIsFemaleToStringConverter");
            else
                return (bool)value ? Properties.Lang.female : Properties.Lang.male;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}