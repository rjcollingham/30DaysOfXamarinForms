using System;
using Android.Graphics;
using Project_01_SimpleStopWatch.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (Button), typeof (MyButtonRenderer))]
namespace Project_01_SimpleStopWatch.Droid
{
	public class MyButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			Button btn = (Button)this.Element;
			if (btn != null && !string.IsNullOrEmpty(btn.FontFamily))
			{
				var label = (Android.Widget.TextView)Control;
				Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, btn.FontFamily);  // font name specified here
				label.Typeface = font;
			}
		}
	}
}

