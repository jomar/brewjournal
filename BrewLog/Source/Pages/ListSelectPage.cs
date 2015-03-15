using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class ListSelectPage : ContentPage
	{
		protected ListView _ListBox;
		protected Action<int> _SelectCallback;

		public ListSelectPage (string title, Action<int> selectCallback)
		{
			_SelectCallback = selectCallback;

			Title = title;

			_ListBox = new ListView()
			{

			};
		}

		protected void ItemSelected(object sender, EventArgs e)
		{
			int id = 0;

			// notify client about seletion?
			if (_SelectCallback != null)
				_SelectCallback.Invoke(id);

			Navigation.PopAsync();
		}
	}
}

