using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class BrewCell : ViewCell
	{
		protected BrewCellImage _Image;
		protected float _CellHeight;
		protected float _LeftMargin;
		protected float _RightMargin;
		protected float _TopMargin;
		protected float _BottomMargin;

		public BrewCell ()
		{
			_CellHeight = 90.0f;
			_LeftMargin = 5.0f;
			_RightMargin = 5.0f;
			_TopMargin = 5.0f;
			_BottomMargin = 5.0f;

			var imageLayout = CreateImageLayout();
			var descriptionLayout = CreateDescriptionLayout();

			var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
				Children = { imageLayout, descriptionLayout }
            };
			View = viewLayout;
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();

			this.Height = _CellHeight;
		}

		protected override void OnPropertyChanged (string propertyName)
		{
			base.OnPropertyChanged (propertyName);
		}

		protected StackLayout CreateAbvLayout()
		{
			var abvLabel = new Label
			{
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.End,
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};
			abvLabel.SetBinding(Label.TextProperty, new Binding("Abv", BindingMode.Default, new AbvBinding()));

			var layout = new StackLayout()
                         {
                             HorizontalOptions = LayoutOptions.End,
                             VerticalOptions = LayoutOptions.End,
							Children = { abvLabel }
                         };
			layout.Padding = new Thickness(_RightMargin, _BottomMargin);
			return layout;
		}

		protected StackLayout CreateImageLayout()
		{
			_Image = new BrewCellImage
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.StartAndExpand
                    };
			_Image.Aspect = Aspect.AspectFit;
			_Image.SetBinding(Image.SourceProperty, new Binding("ImageName", BindingMode.Default, new ImageBinding()));

			var layout = new StackLayout()
                         {
                             HorizontalOptions = LayoutOptions.Start,
                             VerticalOptions = LayoutOptions.Center,
							Children = { _Image }
                         };
			layout.Padding = new Thickness(_LeftMargin, _TopMargin);
			return layout;

		}

		protected StackLayout CreateDescriptionLayout()
	    {
			var nameLabel = new Label
                        {
                            HorizontalOptions = LayoutOptions.Fill,
                            VerticalOptions = LayoutOptions.CenterAndExpand
                        };
			nameLabel.SetBinding(Label.TextProperty, "Name");

			var styleLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand
			};
			styleLabel.SetBinding(Label.TextProperty, "Style");

			var notesLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand
			};
			notesLabel.SetBinding(Label.TextProperty, "Notes");

			var infoLayout = new StackLayout()
			{
				HorizontalOptions =  LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { nameLabel, styleLabel, notesLabel }
			};

			var abvLayout = CreateAbvLayout();

			var layout = new StackLayout()
             {
				HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
				Children = { infoLayout, abvLayout }
             };
			return layout;
		}
	}
}

