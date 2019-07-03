using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HalloBinding
{
    class BooleanToBlueYellowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b)
                return new SolidColorBrush(Colors.CornflowerBlue);

            return new SolidColorBrush(Colors.Yellow);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
