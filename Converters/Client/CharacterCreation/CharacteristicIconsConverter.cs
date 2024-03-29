using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters.Client.CharacterCreation
{
    public class CharacteristicIconsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "/Resources;component/Data/UI/Icons/";

            switch (value.ToString())
            {
                case "character":
                    result += "characterIcon";
                    break;
                case "skills":
                    result += "skillsIcon";
                    break;
                case "job":
                    result += "jobIcon";
                    break;
                case "location":
                    result += "locationIcon";
                    break;
                case "stats":
                    result += "statsIcon";
                    break;
            }

            return result += ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}