using Microsoft.EntityFrameworkCore;

namespace CarShare.Repository.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<OwnerModel> Owners { get; set; }
    }
}
