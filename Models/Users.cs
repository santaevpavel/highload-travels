using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace highload_travels.Models
{
	public class User : Entity{

		[StringLength(100)]
		public string Email { get; set; }

		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		public string Gender { get; set; }

		public long BirthDate { get; set; }

		public List<Visit> Visits { get; set; }
	}
}