using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters
{
    public class SizeFromSizePercentageConventer : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new ArgumentException("Must be only 2 arguments\nSizeFromSizePercentageConventer");
            }
            else if (values[0] is not double || values[1] is not string)
            {
                throw new ArgumentException("Values must contain 1 double type and 1 string type\nSizeFromSizePercentageConventer");
            }

            // check, if we can parse values[1] as string
            if (double.TryParse(values[1] as string, out double persent))
                return (double)values[0] / 100 * persent;
            else
                return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}