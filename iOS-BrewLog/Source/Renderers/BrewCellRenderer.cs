using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using BrewLog;

[assembly:ExportRenderer(typeof(BrewCell), typeof(iOSBrewLog.BrewCellRenderer))]
namespace iOSBrewLog
{
	public class BrewCellRenderer : ViewCellRenderer
	{
		public BrewCellRenderer ()
		{
		}

		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			UITableViewCell cell = base.GetCell(item, reusableCell, tv);
			if (cell != null)
			{
				cell.Layer.BorderColor = UIColor.LightGray.CGColor;
				cell.Layer.BorderWidth = 1.0f;
			}
			return cell;
		}
	}
}

