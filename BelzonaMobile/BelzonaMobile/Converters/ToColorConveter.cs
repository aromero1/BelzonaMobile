using System;
using System.Globalization;
using Xamarin.Forms;

namespace BelzonaMobile.Converters
{
    public class ToSeriesColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var seriesId = value.ToString();
            var isWhite = (seriesId == "55");
            var color = !isWhite ? "#FFFFFF" : "#000000";
            
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
