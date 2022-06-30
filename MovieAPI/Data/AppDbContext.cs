using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
                .HasOne(address => address.Theater)
                .WithOne(theater => theater.Address)
                .HasForeignKey<Theater>(theater => theater.AddressId);

            builder.Entity<Theater>()
                .HasOne(theater => theater.Manager)
                .WithMany(manager => manager.Theaters)
                .HasForeignKey(theater => theater.ManagerId);
        }
        public DbSet<Movie > Movies { get; set; }

        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manager> Managers{ get; set; }
    }
}
