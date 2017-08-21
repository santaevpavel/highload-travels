using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace highload_travels.Models
{
    public class Location : Entity
    {
        public string Place { get; set; }

        [StringLength(50)]
        public string Country { get; set; }    
        
        [StringLength(50)]
        public string City { get; set; }    
    
        public int Distance { get; set; }   

        public ICollection<Visit> Visits { get; set; } 
        
		public override string ToString()
		{
			var builder = new StringBuilder();

			builder.Append("Id=").Append(this.Id).Append("; ");
			builder.Append("Place=").Append(this.Place).Append("; ");
			builder.Append("Country=").Append(this.Country).Append("; ");
			builder.Append("City=").Append(this.City).Append("; ");
			builder.Append("Distance=").Append(this.Distance).Append("; ");

			return builder.ToString();
		}
    }
}