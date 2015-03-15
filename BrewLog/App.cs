using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			global::Brew.SQLite.Connection.Invoke().CreateTable<Brew>();

			var navPage = new NavigationPage(new HomePage());
			return navPage;
		}
	}
}

