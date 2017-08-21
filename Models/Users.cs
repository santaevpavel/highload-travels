using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace highload_travels.Models
{
	public class User : Entity
	{

		[StringLength(100)]
		public string Email { get; set; }

		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		public string Gender { get; set; }

		public long BirthDate { get; set; }

		public virtual ICollection<Visit> Visits { get; set; }
		
		public override string ToString()
		{
			var builder = new StringBuilder();

			builder.Append("Id=").Append(this.Id).Append("; ");
			builder.Append("Email=").Append(this.Email).Append("; ");
			builder.Append("FirstName=").Append(this.FirstName).Append("; ");
			builder.Append("LastName=").Append(this.LastName).Append("; ");
			builder.Append("Gender=").Append(this.Gender).Append("; ");
			builder.Append("BirthDate=").Append(this.BirthDate).Append("; ");

			return builder.ToString();
		}
	}
}