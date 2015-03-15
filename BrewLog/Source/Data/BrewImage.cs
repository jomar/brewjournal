using System;
using SQLite.Net.Attributes;

namespace BrewLog
{
	public enum ImageType
	{
		Brew,	
		Event
	};

	public class BrewImage
	{
		[PrimaryKey, AutoIncrement]
    	public int Id { get; set; }

    	// link back to a brew or event
    	public int ForeginId { get; set; }
    	public int ImageType { get; set; }

    	public DateTime Date { get; set; }
    	public byte[] ImageData { get; set; }
    	public string Notes { get; set; }
	}
}

