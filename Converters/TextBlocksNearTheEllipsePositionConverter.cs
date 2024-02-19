using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters
{
    public class TextBlocksNearTheEllipsePositionConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width && parameter is string param)
            {
                switch (param)
                {
                    case "1Y":
                        return width * Math.Sin(30.5 * Math.PI / 18.0);
                    case "1X":
                        return width * Math.Cos(31.0 * Math.PI / 18.0);
                    case "2Y":
                        return width * Math.Sin(14.5 * Math.PI / 18.0);
                    case "2X":
                        return width * Math.Cos(14.5 * Math.PI / 18.0);
                    case "3Y":
                        return width * Math.Sin(6.0 * Math.PI / 18.0);
                    case "3X":
                        return width * Math.Cos(6.0 * Math.PI / 18.0);
                }
            }

            throw new Exception();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
