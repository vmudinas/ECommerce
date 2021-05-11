using ShippingEcommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ShippingEcommerce.Data.SeedData;

namespace ShippingEcommerce.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        static DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("postgis");

            modelBuilder.Entity<Product>().HasData(DataSeed.ProductData);

            modelBuilder.Entity<Holiday>().HasData(DataSeed.HolidayData);
        }
    }
}