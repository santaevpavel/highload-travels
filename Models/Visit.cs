using System;

namespace highload_travels.Models
{
	public class Visit : Entity
	{
		public int LocationId { get; set; }

        public Location Location { get; set;}

		public int UserId { get; set; }

        public User User { get; set;}

		public int VisitedAt { get; set; }

		public int Mark { get; set; }
	}
}