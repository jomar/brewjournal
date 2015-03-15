using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			using (var db = global::Brew.SQLite.Connection.Invoke())
			{
				db.CreateTable<Brew>();
				db.CreateTable<BrewEvent>();
				db.CreateTable<BrewImage>();
			}

			var navPage = new NavigationPage(new HomePage());
			return navPage;
		}
	}
}

