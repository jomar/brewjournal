using System;
using Xamarin.Forms;
using System.Reflection;

namespace BrewLog
{
	public class EditBrewPage : BrewPage
	{
		protected InputText _NameInput;
		protected InputText _StyleInput;
		protected Editor _NotesInput;
		protected DatePicker _BrewDate;

		public EditBrewPage (int brewId) : base(brewId)
		{
			Title = "Add new brew";

			var brewDateLabel = new Label()
			{
				VerticalOptions = LayoutOptions.Center,
				Text = "Brew date:"
			};

			_BrewDate = new DatePicker()
			{
				Format = "D"
			};

			AddWidgetWithLabel("Brew date:", _BrewDate);

			_NameInput = new InputText()
			{
				Placeholder = "Name"
			};
			AddWidget(_NameInput);

			_StyleInput = new InputText()
			{
				Placeholder = "Style"
			};
			AddWidget(_StyleInput);

			_NotesInput = new MultilineInputText()
			{
				HeightRequest = 100.0f,
				Placeholder = "Notes",
			};

			var saveButton = new Button()
			{
				Text = "Save",
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.White,
				BackgroundColor = Color.Red
			};

			saveButton.Clicked += (object sender, EventArgs e) => 
			{
				Brew brew = new Brew();
				brew.Id = _Id;
				brew.Name = _NameInput.Text;
				brew.Style = _StyleInput.Text;
				brew.BrewDate = _BrewDate.Date;
				brew.Notes = _NotesInput.Text;

				if (SaveBrew(brew))
				{
					Navigation.PopAsync();
				}
			};
			AddWidget(saveButton);

			var addProperty = new AddButton();
			addProperty.Clicked = () => AddProperty("test");

			Refresh();
		}

		protected void AddImage(ImageSource source)
		{
			var image = new ImageWidget
			{
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 150,
				HeightRequest = 150,
				Source = source,
				Placeholder = "Tap to set image"
			};

		}

		protected void AddProperty(string name)
		{
			System.Diagnostics.Debug.WriteLine("Add a new property:  " + name);
		}

		protected void Refresh()
		{
			if (_Id > 0)
			{
				_NameInput.Text = Brew.Name;
				_StyleInput.Text = Brew.Style;
				_NotesInput.Text = Brew.Notes;
				_BrewDate.Date = Brew.BrewDate;
			}
			else
			{
				// default values
				_BrewDate.Date = DateTime.Now;
			}
		}

	}
}

