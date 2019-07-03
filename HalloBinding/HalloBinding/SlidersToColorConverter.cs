using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HalloBinding
{
    class SlidersToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new LinearGradientBrush(Color.FromRgb(System.Convert.ToByte(values[0]), System.Convert.ToByte(values[1]), System.Convert.ToByte(values[2])),Colors.DarkGray,90);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
