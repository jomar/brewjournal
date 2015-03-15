using System;

namespace BrewLog
{
	public class AppSettings
	{
		protected static AppSettings _Instance;

		protected AppSettings ()
		{
		}

		public static AppSettings Instance
		{
			get
			{
				if (_Instance == null)
					_Instance = new AppSettings();
				return _Instance;
			}
		}

		public int BrewCellImageHeight
		{
			get { return 90; }
		}
	}
}

