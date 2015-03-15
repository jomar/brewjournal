using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class ViewBrewPage : BrewPage
	{
		public ViewBrewPage (int brewId) : base(brewId)
		{
			Title = Brew.Name;
			NavigationPage.SetBackButtonTitle(this, "Back");

			var edit = new ToolbarItem("Edit", null, () => Edit() );
			ToolbarItems.Add(edit);



			var deleteButton = new Button()
			{
				Text = "Delete",
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Yellow,
				BackgroundColor = Color.Red
			};

			deleteButton.Clicked += (object sender, EventArgs e) => 
			{
				if (DeleteBrew())
				{
					Navigation.PopAsync();
				}
			};
			AddWidget(deleteButton);

		}

		protected bool DeleteBrew()
		{
			using(var db = global::Brew.SQLite.Connection.Invoke())
			{
				return db.Delete<Brew>(_Id) != 0;
			}
		}

		protected void Edit()
		{
			EditBrewPage edit = new EditBrewPage(_Id);
			Navigation.PushAsync(edit);
		}
	}
}

