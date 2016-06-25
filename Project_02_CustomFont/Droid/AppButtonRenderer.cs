using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Project_02_CustomFont;
using Project_02_CustomFont.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AppButton), typeof(AppButtonRenderer))]
namespace Project_02_CustomFont.Droid
{
	public class AppButtonRenderer : ButtonRenderer
	{
		private GradientDrawable _normal, _pressed;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.SetBackgroundResource(Resource.Drawable.circular);
			}
		}

	}
}

