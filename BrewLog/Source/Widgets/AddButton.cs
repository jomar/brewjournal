using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class AddButton : Image
	{
		public AddButton ()
		{
			Source = ImageSource.FromResource("BrewLog.Resources.Icons.Add.png");
			HeightRequest = 20; // TODO: use font size

			var x = new TapGestureRecognizer();
			x.Tapped += (object sender, EventArgs e) =>
			{
  				this.Opacity = 0.2;
  				this.FadeTo(1.0);

  				if (Clicked != null)
  					Clicked.Invoke();

			};
			GestureRecognizers.Add (x);
		}

		public Action Clicked
		{
			get; set;
		}
	}
}

