using System;
using Microsoft.EntityFrameworkCore;

namespace highload_travels.Models
{
    public class TravelsContext: DbContext
    {
        public TravelsContext(DbContextOptions<TravelsContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
    }
}