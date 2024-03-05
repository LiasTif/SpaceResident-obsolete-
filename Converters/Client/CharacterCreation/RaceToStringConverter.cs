using Converters.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Converters.Client.CharacterCreation
{
    public class RaceToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not char)
            {
                throw new ArgumentException("Argument must be a char type\nRaceToStringConverter");
            }
            else
            {
                if (races.Count < 1)
                    InitRacesDictionary();

                return races[(char)value];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private readonly Dictionary<char, string> races = [];

        private void InitRacesDictionary()
        {
            races.Add('l', Lang.vun_lain);
            races.Add('f', Lang.vun_flant);
            races.Add('t', Lang.vun_ti);
            races.Add('m', Lang.vun_mis_ak);
        }
    }
}