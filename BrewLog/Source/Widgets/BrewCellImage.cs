using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class BrewCellImage : Image
	{
		public BrewCellImage ()
		{
		}

		protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
		{
			if (this.Source != null)
				return new SizeRequest(new Size(AppSettings.Instance.BrewCellImageHeight, AppSettings.Instance.BrewCellImageHeight));
			else
				return new SizeRequest(new Size(0, 0));
		}
	}
}

