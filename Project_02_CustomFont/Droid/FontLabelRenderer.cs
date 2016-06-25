using System;
using Android.Graphics;
using Android.Widget;
using Project_02_CustomFont.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (Label), typeof (FontLabelRenderer))]
namespace Project_02_CustomFont.Droid
{
	public class FontLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			Label lbl = (Label)this.Element;
			if (lbl != null && !string.IsNullOrEmpty(lbl.FontFamily))
			{
				var label = (TextView)Control;
				Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, lbl.FontFamily);
				label.Typeface = font;
			}
		}
	}
}

