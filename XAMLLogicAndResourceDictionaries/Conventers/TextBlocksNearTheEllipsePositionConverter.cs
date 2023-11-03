using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaceResidentDecorativeElements.Conventers
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
                        return width * Math.Sin(310 / 10 * Math.PI / 18);
                    case "1X":
                        return width * Math.Cos(310 / 10 * Math.PI / 18);
                    case "2Y":
                        return width * Math.Sin(160 / 10 * Math.PI / 18);
                    case "2X":
                        return width * Math.Cos(160 / 10 * Math.PI / 18);
                    case "3Y":
                        return width * Math.Sin(65 / 10 * Math.PI / 18);
                    case "3X":
                        return width * Math.Cos(65 / 10 * Math.PI / 18);
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
