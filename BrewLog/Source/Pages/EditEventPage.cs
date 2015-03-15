using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class EditEventPage : PageBase
	{
		protected int _Id;
		protected InputText _NameInput;
		protected DatePicker _EventDate;
		protected Brew _Brew;
		protected BrewEvent _BrewEvent;

		public EditEventPage (int eventId, Brew brew)
		{
			_Id = eventId;
			_Brew = brew;
			Title = eventId > 0 ? "Edit event" : "Add event";

			_EventDate = new DatePicker()
			{
				Format = "D"
			};

			AddWidgetWithLabel("Event date:", _EventDate);

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
				newEvent.EventDate = _EventDate.Date;

				if (SaveEvent(newEvent))
				{
					Navigation.PopAsync();
				}
			};
			AddWidget(saveButton);

			Refresh();
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

		protected BrewEvent BrewEvent
		{
			get
			{
				if (_BrewEvent == null)
				{
					if (_Id != 0)
					{
						using(var db = global::Brew.SQLite.Connection.Invoke())
						{
							var brewEvent = db.Table<BrewEvent>().Where(v => v.Id == _Id);
							if (brewEvent != null && brewEvent.Count() > 0)
								_BrewEvent = brewEvent.First();
							else
								_BrewEvent = new BrewEvent() { Id = _Id };
						}
					}
					else
						_BrewEvent = new BrewEvent();
				}

				return _BrewEvent;
			}
		}

		protected void Refresh()
		{
			if (_Id > 0)
			{
				_NameInput.Text = BrewEvent.Name;
				_EventDate.Date = BrewEvent.EventDate;
			}
			else
			{
				// default values
				_EventDate.Date = DateTime.Now;
			}
		}

	}
}

