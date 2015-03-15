using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace BrewLog
{
	public class HomePage : PageBase
	{
		protected BrewList _BrewList;

		public HomePage ()
		{
			NavigationPage.SetBackButtonTitle(this, "Back");

			/*
			Command<int> navigateCommand =
				new Command<int>(async (int id) =>
				{
					EditBrew(id);
				});
				*/
			Action addAction = ()=> AddNewBrew();
			ToolbarItems.Add(new ToolbarItem("+", null, addAction));
			Title = "Brew Journal";

			_BrewList = new BrewList();
			_BrewList.ItemTemplate = new DataTemplate(typeof(BrewCell));
			_BrewList.HasUnevenRows = true;
			// do not allow items to be selected
			_BrewList.ItemTapped += (sender, e) => {
			    // do something with e.Item
				object item = ((ListView)sender).SelectedItem;
				if (item != null && item is Brew)
				{
					int id = ((Brew)item).Id;
					if (id > 0)
					{
						ViewBrewPage view = new ViewBrewPage(id);
						Navigation.PushAsync(view);
					}
					else
					{
						EditBrewPage view = new EditBrewPage(0);
						Navigation.PushAsync(view);
					}
			    	((ListView)sender).SelectedItem = null; // de-select the row
			    }
			};
			Content = _BrewList;
		}

		protected override void Refresh()
		{
			base.Refresh();

			var brews = GetBrews();
			if (brews != null && brews.Count > 0)
			{
				_BrewList.ItemsSource = brews;
			}
			else
			{
				_BrewList.ItemsSource = GetEmptyBrewsTip();
			}
		}

		protected Brew[] GetEmptyBrewsTip()
		{
			var tip = new Brew[]
			{
				new Brew()
				{
					Id = -1,
					Name = "Click here or on the + sign above to add a your first Brew"
				}
			};
			return tip;
		}

		protected List<Brew> GetBrews()
		{
			List<Brew> brews = new List<Brew>();

			using (var connection = global::Brew.SQLite.Connection.Invoke())
			{
				var allBrewsQuery = connection.Table<Brew>();
				foreach(var brew in allBrewsQuery)
				{
					brews.Add(brew);		
				}
				connection.Close();
			}
			return brews;
		}

		protected void AddNewBrew()
		{
			Page page = new EditBrewPage(0);
			Navigation.PushAsync(page);

		}

		protected void EditBrew(int id)
		{
			Page page = new EditBrewPage(id);
			Navigation.PushAsync(page);
		}
	}
}

