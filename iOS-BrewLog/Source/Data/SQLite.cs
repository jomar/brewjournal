using System;
using Xamarin.Forms;
using BrewLog;
using System.IO;
using SQLite;

/*
[assembly: Xamarin.Forms.Dependency (typeof (iOSBrewLog.SQLite))]
namespace iOSBrewLog
{
	public class SQLite : ISQLite 
	{
		public SQLite () {}

		public ISQLiteConnection GetConnection ()
		{
			string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var conn = new SQLiteConnection (System.IO.Path.Combine (folder, "brews.db"));
			return new SQLiteConnectioniOS(conn);
		}
	}
}
*/
