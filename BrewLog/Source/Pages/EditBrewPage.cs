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

			var image = new ImageWidget
			{
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 150,
				HeightRequest = 150,
				Placeholder = "Tap to set image"
			};

			_NameInput = new InputText()
			{
				Placeholder = "Name"
			};

			_StyleInput = new InputText()
			{
				Placeholder = "Style"
			};

			var _BrewDateLabel = new Label()
			{
				VerticalOptions = LayoutOptions.Center,
				Text = "Brew date:"
			};

			_BrewDate = new DatePicker()
			{
				Format = "D"
			};

			var _BrewDateLine = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
				Children = { _BrewDateLabel, _BrewDate }
			};

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

			var addProperty = new AddButton();
			addProperty.Clicked = () => AddProperty("test");

			var layout = new StackLayout()
             {
				HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
				Children = { image, _NameInput, _StyleInput, addProperty, _BrewDateLine, _NotesInput, saveButton }
             };
			layout.Padding = 5.0f;

			Content = layout;

			Refresh();
		}

		protected void AddProperty(string name)
		{
			System.Diagnostics.Debug.WriteLine("Add a new property:  " + name);
		}

		protected void Refresh()
		{
			_NameInput.Text = Brew.Name;
			_StyleInput.Text = Brew.Style;
			_NotesInput.Text = Brew.Notes;
			_BrewDate.Date = Brew.BrewDate;
		}

	}
}

