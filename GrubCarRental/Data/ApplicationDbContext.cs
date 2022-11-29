using GrubCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace GrubCarRental.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Renter> Renters { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
