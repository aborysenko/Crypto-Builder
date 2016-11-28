using System;
using System.Globalization;
using System.Windows.Data;

namespace CryptoBuilder.UI.Helper
{
    public class ByteToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] byteValue = (byte[])value;

            if (byteValue == null)
                return "";

            return BitConverter.ToString(byteValue).Replace("-","");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            return Helper.StringToByteArray(value.ToString()); ;
        }
    }
}
