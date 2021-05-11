using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShippingEcommerce.Data;

namespace TestShippingEcommerceService
{
    public static class DbContextHelper
    {
        public static DataContext CreateDbContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()                
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("commerce_db")
                .EnableSensitiveDataLogging(true)
                .UseInternalServiceProvider(serviceProvider)
                .Options;
            var dbContext = new DataContext(options);
            //dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
