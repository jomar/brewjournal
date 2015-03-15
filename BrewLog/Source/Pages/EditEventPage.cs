using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class EditEventPage : PageBase
	{
		protected int _Id;
		protected InputText _NameInput;
		protected Brew _Brew;
		public EditEventPage (int eventId, Brew brew)
		{
			_Id = eventId;
			_Brew = brew;
			Title = eventId > 0 ? "Edit event" : "Add event";

			_NameInput = new InputText()
			{
				Placeholder = "Name"
			};
			AddWidget(_NameInput);

			var saveButton = new Button()
			{
				Text = "Save",
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.White,
				BackgroundColor = Color.Red
			};

			saveButton.Clicked += (object sender, EventArgs e) => 
			{
				BrewEvent newEvent = new BrewEvent();
				newEvent.Id = _Id;
				newEvent.Name = _NameInput.Text;
				newEvent.BrewId = _Brew.Id;

				if (SaveEvent(newEvent))
				{
					Navigation.PopAsync();
				}
			};
			AddWidget(saveButton);
		}

		protected bool VerifyValues(BrewEvent brewEvent)
		{
			if (brewEvent.Name == null || brewEvent.Name.Length == 0)
			{
				return false;
			}

			return true;
		}


		protected bool SaveEvent(BrewEvent brewEvent)
		{
			if (VerifyValues(brewEvent))
			{
				using (var db = global::Brew.SQLite.Connection.Invoke())
				{
					db.Insert(brewEvent);
					db.Commit();
					db.Close();
				}
				return true;
			}
			else
				return false;
		}
	}
}

