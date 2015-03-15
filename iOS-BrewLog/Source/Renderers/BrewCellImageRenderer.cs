using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using BrewLog;
using iOSBrewLog;

[assembly: ExportRenderer (typeof (BrewCellImage), typeof (BrewCellImageRenderer))]
namespace iOSBrewLog
{
	public class BrewCellImageRenderer : ImageRenderer
	{
		public BrewCellImageRenderer ()
		{
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (Control != null && Control is UIImageView)
			{
				UIImageView iv = (UIImageView)Control;
				if (iv.Image != null)
				{
					if (iv.Image.Size.Width != AppSettings.Instance.BrewCellImageHeight)
					{
						iv.Image = iv.Image.Scale(new CoreGraphics.CGSize(AppSettings.Instance.BrewCellImageHeight, AppSettings.Instance.BrewCellImageHeight));
					}
					iv.Layer.BorderWidth = 2;
					iv.Layer.BorderColor = UIColor.Green.CGColor;
				}
			}
		}
	}
}

