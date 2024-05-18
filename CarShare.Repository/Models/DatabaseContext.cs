using Microsoft.EntityFrameworkCore;

namespace CarShare.Repository.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonCarModel>()
                .HasOne(p => p.Car)
                .WithMany(p => p.CarPersons)
                .HasForeignKey(p => p.CarID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookingModel>()
                .HasOne(b => b.Car)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<OwnerModel> Owners { get; set; }
        public DbSet<PersonCarModel> PersonCars { get; set; }
    }
}
