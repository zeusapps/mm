using System;
using System.Globalization;
using System.Windows.Data;

namespace Mm.Client.Converters
{
    public class ByteToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[] data))
            {
                return null;
            }

            return System.Convert.ToBase64String(data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
