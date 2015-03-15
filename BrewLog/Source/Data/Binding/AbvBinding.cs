using System;
using Xamarin.Forms;
using System.Globalization;

namespace BrewLog
{
	public class AbvBinding : IValueConverter
	{
		public AbvBinding ()
		{
		}

		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType == typeof(System.String))
			{
				if (value != null && !value.Equals(0.0f))
				{
					return "Abv: " + value.ToString() + "%";
				}
				else
					return null;
			}
			else
				return null;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

