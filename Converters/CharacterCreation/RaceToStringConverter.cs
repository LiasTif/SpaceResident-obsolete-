using Converters.Properties;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters.CharacterCreation
{
    public class RaceToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is char race)
            {
                switch (race)
                {
                    case 'l':
                        return Lang.vun_lain;
                    case 'f':
                        return Lang.vun_flant;
                    case 't':
                        return Lang.vun_ti;
                    case 'm':
                        return Lang.vun_mis_ak;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
