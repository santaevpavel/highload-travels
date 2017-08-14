using System;
using System.ComponentModel.DataAnnotations;

namespace highload_travels.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }
}