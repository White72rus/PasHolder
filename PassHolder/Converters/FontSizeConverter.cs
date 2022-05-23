using System;
using System.Globalization;
using System.Windows.Data;

namespace PassHolder.Converters
{
    public class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace((string)value))
                value = "1";

            double.TryParse(value?.ToString(), out double result);

            if (result.ToString() == "0")
                result = 1;

            return result;
        }
    }
}
