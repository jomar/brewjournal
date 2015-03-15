using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class PageBase : ContentPage
	{
		protected StackLayout _Layout;

		public PageBase ()
		{
			_Layout = new StackLayout()
            {
				HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
               	Padding = 5.0f,
			};

			Content = _Layout;

		}

		protected View AddWidget(View widget)
		{
			_Layout.Children.Add(widget);
			return widget;
		}

		protected View AddWidgetWithLabel(string labelText, View widget)
		{
			var label = new Label()
			{
				VerticalOptions = LayoutOptions.Center,
				Text = labelText
			};

			return AddWidget(new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
				Children = { label, widget }
			});
		}
	}
}

