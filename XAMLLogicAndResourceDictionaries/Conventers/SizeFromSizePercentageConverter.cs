using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaceResidentClient.Converters
{
    internal class SizeFromSizePercentageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
                throw new ArgumentException("Must be only 2 arguments");
            else if (values[0] is not double || values[1] is not string)
                throw new ArgumentException("Values must contain 1 double type and 1 string type");

            if (values[0] is double elemSize)
                if (double.TryParse(values[1] as string, out double persent))
                    return elemSize / 100 * persent;

            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}