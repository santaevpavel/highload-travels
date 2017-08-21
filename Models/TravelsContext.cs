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
            modelBuilder.Entity<User>()
                .HasMany(u => u.Visits)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Location>()
                .HasMany(u => u.Visits)
                .WithOne(v => v.Location)
                .HasForeignKey(v => v.LocationId);
        }
    }
}