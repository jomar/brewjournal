using System;
using Xamarin.Forms;
using System.Globalization;

namespace BrewLog
{
	public class ImageBinding : IValueConverter
	{
		public ImageBinding()
		{
		}

		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType == typeof(ImageSource))
			{
				if (value != null)
				{
					// TODO: check that resource exist
					return ImageSource.FromResource((string)value);
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

