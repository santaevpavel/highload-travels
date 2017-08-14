using System;

namespace highload_travels.Models
{
	public class Visit
	{
		public int Id { get; set; }

		public int Location { get; set; }

		public int User { get; set; }

		public int VisitedAt { get; set; }

		public int Mark { get; set; }
	}
}