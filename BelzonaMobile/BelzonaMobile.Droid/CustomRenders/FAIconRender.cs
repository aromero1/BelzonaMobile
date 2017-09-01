using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;



[assembly: ExportRenderer(typeof(BelzonaMobile.Controls.FAIcon), typeof(BelzonaMobile.Droid.CustomRenders.FAIconRender))]
namespace BelzonaMobile.Droid.CustomRenders
{
  public class FAIconRender : LabelRenderer
  {
    protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
    {
      base.OnElementChanged(e);
      Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/fontAwesome.ttf");
      Control.Typeface = font;
    }
  }
}