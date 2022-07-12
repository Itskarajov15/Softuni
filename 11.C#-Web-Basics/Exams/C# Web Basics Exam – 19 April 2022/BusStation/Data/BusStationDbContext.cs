using BusStation.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace BusStation.Data
{
    public class BusStationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BusStation;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => new { x.Email, x.Username })
                .IsUnique(true);
        }
    }
}