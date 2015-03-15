using System;
using SQLite.Net.Attributes;

namespace BrewLog
{
	public class Brew
	{
		[PrimaryKey, AutoIncrement]
    	public int Id { get; set; }

		public string Name { get; set; }
		public DateTime BrewDate { get; set; }
		public string Notes { get; set; }
		public string Style { get; set; }
		public DateTime BottleDate { get; set; }
		public string ImageName { get; set; }
		public string OriginalGravity { get; set; }
		public string FinalGravity { get; set; }
		public float Abv { get; set; }

	}
}

