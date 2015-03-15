using System;
using Xamarin.Forms.Platform.iOS;
using BrewLog;
using iOSBrewLog;
using Xamarin.Forms;
using UIKit;

[assembly: ExportRenderer (typeof (ImageWidget), typeof (ImageWidgetRenderer))]
namespace iOSBrewLog
{
	public class ImageWidgetRenderer : ImageRenderer
	{
		protected UILabel label;

		public ImageWidgetRenderer ()
		{
			label = new UILabel();
			label.TextAlignment = UITextAlignment.Center;
			label.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			label.TextColor = UIColor.FromRGB(195.0f/255.0f, 195.0f/255.0f, 195.0f/255.0f);
			label.LineBreakMode = UILineBreakMode.WordWrap;
			label.Lines = 2;
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);

			Control.Layer.BorderWidth = 0.5f;
			Control.Layer.BorderColor = UIColor.FromRGB(195.0f/255.0f, 195.0f/255.0f, 195.0f/255.0f).CGColor;
			Control.Layer.CornerRadius = 5.0f;

			if (Control.Image == null && Element is ImageWidget)
			{
				label.Text = ((ImageWidget)Element).Placeholder;
				if (label.Superview == null)
				{
					Control.AutosizesSubviews = true;
					Control.AddSubview(label);
				}
			}
			else if (Control.Image != null)
			{
				if (label.Superview != null)
					label.RemoveFromSuperview();
			}
		}
	}
}

