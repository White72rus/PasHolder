using System;
using System.Globalization;
using System.Security;
using System.Windows.Data;

namespace PassHolder.Converters
{
    public class SecureStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SecureString secureString)
            {
                return secureString.ToString();
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    SecureString secureString = new SecureString();
                    foreach (char item in str)
                    {
                        secureString.AppendChar(item);
                    }
                    return secureString;
                }
            }
            return String.Empty;
        }
    }
}
