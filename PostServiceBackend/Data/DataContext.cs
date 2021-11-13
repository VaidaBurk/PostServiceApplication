using Microsoft.EntityFrameworkCore;
using PostServiceBackend.Entities;

namespace PostServiceBackend.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelMachine> ParcelMachines { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParcelMachine>()
                .HasMany(m => m.Parcels)
                .WithOne()
                .HasForeignKey(p => p.ParcelMachineId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Parcel>()
                .Property(p => p.Weight)
                .HasPrecision(5, 2);
        }
    }
}
