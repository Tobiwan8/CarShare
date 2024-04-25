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
            modelBuilder.Entity<PersonModel>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<PersonModel>(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OwnerModel>()
                .HasOne(o => o.Person)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<OwnerModel> Owners { get; set; }
    }
}
