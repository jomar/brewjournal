using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;

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
		public string ImageName { get; set; }
		public string OriginalGravity { get; set; }
		public string FinalGravity { get; set; }
		public float Abv { get; set; }

//		public List<BrewEvent> Events { get; set; }
//		public List<BrewImage> Images { get; set; }

	}
}

