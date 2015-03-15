using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using BrewLog;
using iOSBrewLog;

[assembly: ExportRenderer (typeof (InputText), typeof (InputTextRenderer))]
namespace iOSBrewLog
{
	public class InputTextRenderer : EntryRenderer
	{
		public InputTextRenderer ()
		{
		}

		protected override void UpdateNativeWidget ()
		{
			base.UpdateNativeWidget ();

			Control.AutocapitalizationType = UIKit.UITextAutocapitalizationType.Sentences;
		}
	}
}

