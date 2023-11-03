using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaceResidentClient.Converters
{
    internal class TextBlocksNearTheEllipsePositionConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width && parameter is string param)
            {
                switch (param)
                {
                    case "1Y":
                        return width * Math.Sin(305.0 / 10.0 * Math.PI / 18.0);
                    case "1X":
                        return width * Math.Cos(310.0 / 10.0 * Math.PI / 18.0);
                    case "2Y":
                        return width * Math.Sin(145.0 / 10.0 * Math.PI / 18.0);
                    case "2X":
                        return width * Math.Cos(145.0 / 10.0 * Math.PI / 18.0);
                    case "3Y":
                        return width * Math.Sin(60.0 / 10.0 * Math.PI / 18.0);
                    case "3X":
                        return width * Math.Cos(60.0 / 10.0 * Math.PI / 18.0);
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
