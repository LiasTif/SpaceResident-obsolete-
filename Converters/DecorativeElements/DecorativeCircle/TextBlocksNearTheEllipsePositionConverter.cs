using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Converters.DecorativeElements.DecorativeCircle
{
    public class TextBlocksNearTheEllipsePositionConverter : IValueConverter
    {
        private const int coordinatesCount = 3;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width && parameter is string param)
            {
                if (koordinatesPairs.Count < 1)
                    InitRacesDictionary();

                // use formula to calculate position of TextBlock
                double calculations = koordinatesPairs[param] * Math.PI / 18.0;

                double finalCalculations = param.Contains('X') ? Math.Cos(calculations) : Math.Sin(calculations);

                return width * finalCalculations;
            }
            else
            {
                throw new Exception();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private readonly Dictionary<string, double> koordinatesPairs = [];
        private readonly Dictionary<int, double> koordinatesPositionPairs = new()
        {
            { 1, 31.0 },
            { 2, 14.5 },
            { 3, 6.0 },
        };

        private void InitRacesDictionary()
        {
            int i = 1;
            while (i < coordinatesCount + 1)
            {
                string coordinateX = $"{i}X";
                string coordinateY = $"{i}Y";

                koordinatesPairs.Add(coordinateX, koordinatesPositionPairs[i]);
                koordinatesPairs.Add(coordinateY, koordinatesPositionPairs[i]);
                i++;
            }
        }
    }
}