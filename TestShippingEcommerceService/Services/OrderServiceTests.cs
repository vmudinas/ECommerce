using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NodaTime;
using NodaTime.Extensions;
using ShippingEcommerce.Data;
using ShippingEcommerce.Models;
using ShippingEcommerce.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestShippingEcommerceService.Services
{
    public class OrderServiceTests
    {
        private MockRepository mockRepository;

        private Mock<DataContext> mockDataContext;
        private Mock<IMapper> mockMapper;
        private Mock<ILogger<OrderService>> mockLogger;
        private Mock<IConfiguration> mockConfiguration;

        public OrderServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockMapper = this.mockRepository.Create<IMapper>();
            this.mockLogger = this.mockRepository.Create<ILogger<OrderService>>();
            this.mockConfiguration = this.mockRepository.Create<IConfiguration>();
        }

        private OrderService CreateService()
        {            
            return new OrderService(
                DbContextHelper.CreateDbContext(),
                this.mockMapper.Object,
                this.mockLogger.Object,
                this.mockConfiguration.Object);
        }    

        [Theory]
        [InlineData(1, true, 2021, 06, 13, 2021, 06, 13)]
        [InlineData(13, true, 2021, 05, 11, 2021, 05, 23)]
        [InlineData(18, true, 2021, 05, 11, 2021, 05, 29)]
        [InlineData(15, false, 2021, 05, 11, 2021, 06, 01)]
        [InlineData(18, false, 2021, 05, 11, 2021, 06, 04)]
        [InlineData(19, true, 2021, 05, 11, 2021, 05, 30)]
        [InlineData(20, false, 2021, 05, 11, 2021, 06, 08)]
        [InlineData(14, false, 2021, 05, 11, 2021, 05, 31)]
        [InlineData(16, false, 2021, 05, 11, 2021, 06, 02)]
        public void CalculateExpextedShippingDate_ExpectedBehavior(int maxBusinessDaysToShip, 
            bool shipOnWeekends, 
            int orderYear, 
            int orderMonth,
            int orderDay,
            int orderYearExpected, 
            int orderMonthExpected, 
            int orderDayExpected)
        {            
            // Arrange
            var service = this.CreateService();
            ProductListItem product =  new ProductListItem {
                InventoryQuantity = 1, 
                MaxBusinessDaysToShip = maxBusinessDaysToShip, 
                ShipOnWeekends = shipOnWeekends,
                ProductId = 1, 
                ProductName = "TestProduct" };

            var orderDate = new LocalDate(orderYear, orderMonth, orderDay);
            var shipOnWeekendsExpected = new LocalDate(orderYearExpected, orderMonthExpected, orderDayExpected);

            // Act
            var result = service.CalculateExpextedShippingDate(product, orderDate);

            // Assert
            Assert.Equal(result, shipOnWeekendsExpected);
        }

        [Theory]
        [InlineData(1, false, 2021, 06, 13, 2021, 06, 12)]
        [InlineData(13, false, 2021, 05, 11, 2021, 05, 23)]
        [InlineData(18, false, 2021, 05, 11, 2021, 05, 29)]
        [InlineData(15, true, 2021, 05, 11, 2021, 06, 01)]
        [InlineData(18, true, 2021, 05, 11, 2021, 06, 04)]
        [InlineData(19, false, 2021, 05, 11, 2021, 05, 30)]
        [InlineData(20, true, 2021, 05, 11, 2021, 06, 08)]
        [InlineData(14, true, 2021, 05, 11, 2021, 05, 31)]
        [InlineData(16, true, 2021, 05, 11, 2021, 06, 02)]
        public void CalculateExpextedShippingDate_Fail (int maxBusinessDaysToShip,
           bool shipOnWeekends,
           int orderYear,
           int orderMonth,
           int orderDay,
           int orderYearExpected,
           int orderMonthExpected,
           int orderDayExpected)
        {
            // Arrange
            var service = this.CreateService();
            ProductListItem product = new ProductListItem
            {
                InventoryQuantity = 1,
                MaxBusinessDaysToShip = maxBusinessDaysToShip,
                ShipOnWeekends = shipOnWeekends,
                ProductId = 1,
                ProductName = "TestProduct"
            };

            var orderDate = new LocalDate(orderYear, orderMonth, orderDay);
            var shipOnWeekendsExpected = new LocalDate(orderYearExpected, orderMonthExpected, orderDayExpected);

            // Act
            var result = service.CalculateExpextedShippingDate(product, orderDate);

            // Assert
            Assert.NotEqual(result, shipOnWeekendsExpected);
        }
    }
}
