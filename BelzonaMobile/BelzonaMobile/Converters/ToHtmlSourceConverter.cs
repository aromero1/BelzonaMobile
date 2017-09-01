using System;
using System.Globalization;
using Xamarin.Forms;

namespace BelzonaMobile.Converters
{
    public class ToHtmlSourceConverter : IValueConverter 
    {
        public ToHtmlSourceConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var htmltext = new HtmlWebViewSource();
            //htmltext.Html = (string)value;
            htmltext.Html = @"<html><body>
  <h1>Xamarin.Forms</h1>
  <p>Welcome to WebView.</p>
  </body></html>";
            return htmltext;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
