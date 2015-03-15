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
		}

		protected void Edit()
		{
			EditBrewPage edit = new EditBrewPage(_Id);
			Navigation.PushAsync(edit);
		}
	}
}

