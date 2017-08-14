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

        public DbSet<User> Users { get; set; }

        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visit>()
                .HasOne(p => p.User)
                .WithMany(b => b.Visits)
                .HasForeignKey(b => b.UserId);
                
            modelBuilder.Entity<Visit>()
                .HasOne(p => p.Location)
                .WithMany(b => b.Visits)
                .HasForeignKey(b => b.LocationId);
        }
    }
}