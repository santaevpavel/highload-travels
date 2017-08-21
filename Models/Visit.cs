using System;
using System.Text;

namespace highload_travels.Models
{
	public class Visit : Entity
	{
		public int LocationId { get; set; }

        public virtual Location Location { get; set;}

		public int UserId { get; set; }

        public virtual User User { get; set;}

		public int VisitedAt { get; set; }

		public int Mark { get; set; }

		public override string ToString()
		{
			var builder = new StringBuilder();

			builder.Append("Id=").Append(this.Id).Append("; ");
			builder.Append("Location=<").Append(this.Location?.ToString()).Append(">; ");
			builder.Append("User=<").Append(this.User?.ToString()).Append(">; ");
			builder.Append("VisitedAt=").Append(this.VisitedAt).Append("; ");
			builder.Append("Mark=").Append(this.Mark).Append("; ");

			return builder.ToString();
		}
	}
}