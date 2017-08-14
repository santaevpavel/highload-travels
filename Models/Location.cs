using System;
using System.ComponentModel.DataAnnotations;

namespace highload_travels.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Place { get; set; }

        [StringLength(50)]
        public string Country { get; set; }    
        
        [StringLength(50)]
        public string City { get; set; }    
    
        public int Distance { get; set; }    
    }
}