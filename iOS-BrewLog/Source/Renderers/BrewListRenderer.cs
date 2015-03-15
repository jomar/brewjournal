using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using BrewLog;

[assembly:ExportRenderer(typeof(BrewList), typeof(iOSBrewLog.BrewListRenderer))]
namespace iOSBrewLog
{
	public class BrewListRenderer : ListViewRenderer
	{
		public BrewListRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
            base.OnElementChanged (e);

            if (Control == null)
                return;

            var tableView = Control as UITableView;
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        }
	}
}

