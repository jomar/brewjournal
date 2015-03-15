using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using BrewLog;
using iOSBrewLog;
using Xamarin.Forms;
using Foundation;
using System.Runtime.CompilerServices;

[assembly: ExportRenderer (typeof (MultilineInputText), typeof (MultilineInputRenderer))]
namespace iOSBrewLog
{
	public class MultilineInputRenderer : EditorRenderer
	{
		protected String _DefaultText = "";

		public String Placeholder
		{
			set
			{
				_DefaultText = value;
				if (Control.Text == null || Control.Text.Length == 0)
				{
					Control.Text = _DefaultText;
					Control.TextColor= UIColor.FromRGB(195.0f/255.0f, 195.0f/255.0f, 195.0f/255.0f);
				}
			}

			get { return _DefaultText; }
		}

		public MultilineInputRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Editor> e)
		{
			base.OnElementChanged (e);

			try
			{
				Control.Layer.BorderWidth = .3f;
				Control.Layer.BorderColor = UIColor.LightGray.CGColor;
				Control.Layer.CornerRadius = 5.0f;
				Control.Font = UIFont.SystemFontOfSize(UIFont.LabelFontSize);
				if (Element != null)
					Placeholder = ((MultilineInputText)Element).Placeholder;
				Control.Started += (object sender, EventArgs args) => 
				{
					if (Control.Text == _DefaultText)
					{
						Control.Text = "";
						Control.TextColor= UIColor.Black;
					}
				};
				Control.Ended += (object sender, EventArgs args) => 
				{
					if (Control.Text == "")
					{
						Control.Text = _DefaultText;
						Control.TextColor= UIColor.FromRGB(195.0f/255.0f, 195.0f/255.0f, 195.0f/255.0f);
					}
				};
				Control.TextContainerInset = new UIEdgeInsets(4, 2, 4, 2);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
		}


	}
}

