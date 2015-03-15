using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace BrewLog
{
	public class BrewEvent
	{
		[PrimaryKey, AutoIncrement]
    	public int Id { get; set; }

    	// link back to a brew
    	public int BrewId { get; set; }

		public DateTime EventDate { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		//public List<BrewImage> Images { get; set; }
	}
}

