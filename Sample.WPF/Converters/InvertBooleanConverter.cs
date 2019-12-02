using System;
using System.Globalization;
using System.Windows.Data;

namespace Sample.WPF.Converters
{
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool trueOrFalse)
            {
                return !trueOrFalse;
            }

            throw new Exception("Unsupported data type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("This only works one way");
        }
    }
}
