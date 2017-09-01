using System;
using System.ComponentModel;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BelzonaMobile.Controls.HtmlLabel), typeof(BelzonaMobile.iOS.CustomRenders.HtmlLabelRender))]
namespace BelzonaMobile.iOS.CustomRenders
{

    public class HtmlLabelRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
            {
                var attr = new NSAttributedStringDocumentAttributes();
                var nsError = new NSError();
                attr.DocumentType = NSDocumentType.HTML;

                //var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);
                UIKit.UIFont font = Control.Font;
                string fontName = font.Name;
                System.nfloat fontSize = font.PointSize;
                string htmlContents = "<span style=\"font-family: '" + fontName + "'; font-size: " + fontSize + "\">" + Element.Text + "</span>";
                var myHtmlData = NSData.FromString(htmlContents, NSStringEncoding.Unicode);
                Control.Lines = 0;
                Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
                {
                    var attr = new NSAttributedStringDocumentAttributes();
                    var nsError = new NSError();
                    attr.DocumentType = NSDocumentType.HTML;

                    var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);
                    Control.Lines = 0;
                    Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
                }
            }
        }

    }
}
