using System;
using System.Globalization;
using Xamarin.Forms;

namespace BelzonaMobile.Converters
{
    public class ToYouTubeUrlConverter : IValueConverter 
    {
       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return YouTubeVideoIdExtension.Convert((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
