using System;
using System.Globalization;
using Xamarin.Forms;

namespace BelzonaMobile.Converters
{
    public class ImageUrlConverter : IValueConverter 
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var url = App.ProductsImageUrl + value.ToString();
            return url;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return value;
        }
    }
}
