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
            //Configure Person to UserModel relationship
            //modelBuilder.Entity<PersonCarModel>()
            //.HasKey(pc => new { pc.PersonID, pc.CarID });

            //modelBuilder.Entity<PersonModel>()
            //    .HasOne(p => p.User)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PersonCarModel>()
            //    .HasOne(p => p.Person)
            //    .WithMany(p => p.PersonCars)
            //    .HasForeignKey(p => p.PersonID)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonCarModel>()
                .HasOne(p => p.Car)
                .WithMany(p => p.CarPersons)
                .HasForeignKey(p => p.CarID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<OwnerModel>()
            //    .HasOne(o => o.Person)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<CarModel>()
            //    .HasOne(o => o.Owner)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<OwnerModel>()
            //    .HasMany(o => o.Cars)
            //    .WithOne(c => c.Owner)
            //    .HasForeignKey(c => c.OwnerID)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<BookingModel>()
            //    .HasOne(b => b.Person)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingModel>()
                .HasOne(b => b.Car)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<OwnerModel> Owners { get; set; }
        public DbSet<PersonCarModel> PersonCars { get; set; }
    }
}
