using System;
using Xamarin.Forms;
using System.Collections.Generic;

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

			var addEventButton = new AddButton();
			addEventButton.Clicked += new Action(() =>
			{
				EditEventPage eventPage = new EditEventPage(0, Brew);
				Navigation.PushAsync(eventPage);
			});
			AddWidgetWithLabel("Events:", addEventButton);

			PopulateEvents(brewId);

			var addPhotosButton = new AddButton();
			AddWidgetWithLabel("Photos:", addPhotosButton);

			PopulateImages(brewId);

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

		protected void PopulateEvents(int brewId)
		{
			List<BrewEvent> events = new List<BrewEvent>();

			using (var connection = global::Brew.SQLite.Connection.Invoke())
			{
				var allEventsQuery = connection.Table<BrewEvent>().Where(e => e.BrewId == brewId);
				foreach(var e in allEventsQuery)
				{
					AddEvent(e);
				}
				connection.Close();
			}
		}

		protected void AddEvent(BrewEvent brewEvent)
		{
			var eventRow = new Label()
			{
				Text = " - " + brewEvent.EventDate.ToString() + " " +
					brewEvent.Name + " " +
					brewEvent.Description
			};
			AddWidget(eventRow);
		}

		protected void PopulateImages(int brewId)
		{
			// todo get all images and add them nicely to layout
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

