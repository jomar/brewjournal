using System;
using SQLite.Net;

namespace Brew
{
	public class SQLite
	{
		public static Func<SQLiteConnection> Connection { get; set; }
	}
}