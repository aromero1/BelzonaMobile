using System;
using BelzonaMobile.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ThreeLineLabel), typeof(BelzonaMobile.iOS.CustomRenders.ThreeLineLabelRenderer))]

namespace BelzonaMobile.iOS.CustomRenders
{
    public class ThreeLineLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Control.Lines = 3;
        }
    }
}

