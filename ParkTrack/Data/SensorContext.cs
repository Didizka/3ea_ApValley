using Microsoft.EntityFrameworkCore;
using ParkTrack.Models;

namespace ParkTrack.Data
{
    public class SensorContext : DbContext
    {

        public SensorContext(DbContextOptions options) : base(options) { }
        public DbSet<Sensor> Sensors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>().ToTable("Sensors");

            modelBuilder.Entity<Sensor>()
                .Property(b => b.TokenAddedAt)
                .HasDefaultValueSql("getdate()");
        }
    }
}
