using System.Collections.Generic;
using ShippingEcommerce.Data.Entities;

namespace ShippingEcommerce.Data.SeedData
{
    public static class DataSeed
    {
        public static readonly IEnumerable<Product> ProductData = new List<Product>
        {
            new()
            {
                ProductId =  1,
                ProductName = "fugiat exercitation adipisicing",
                InventoryQuantity = 43,
                ShipOnWeekends = true,
                MaxBusinessDaysToShip = 13
            },
            new()
            {
                ProductId =  2,
                ProductName = "mollit cupidatat Lorem",
                InventoryQuantity = 70,
                ShipOnWeekends = true,
                MaxBusinessDaysToShip = 18
            },
            new()
            {
                ProductId =  3,
                ProductName = "non quis sint",
                InventoryQuantity = 33,
                ShipOnWeekends = false,
                MaxBusinessDaysToShip = 15
            },
            new()
            {
                ProductId =  4,
                ProductName = "voluptate cupidatat non",
                InventoryQuantity = 52,
                ShipOnWeekends = false,
                MaxBusinessDaysToShip = 18
            },
            new()
            {
                ProductId =  5,
                ProductName = "anim amet occaecat",
                InventoryQuantity = 39,
                ShipOnWeekends = true,
                MaxBusinessDaysToShip = 19
            },
            new()
            {
                ProductId =  6,
                ProductName = "cillum deserunt elit",
                InventoryQuantity = 47,
                ShipOnWeekends = false,
                MaxBusinessDaysToShip = 20
            },
            new()
            {
                ProductId =  7,
                ProductName = "adipisicing reprehenderit et",
                InventoryQuantity = 71,
                ShipOnWeekends = false,
                MaxBusinessDaysToShip = 15
            },
            new()
            {
                ProductId =  8,
                ProductName = "ex mollit laboris",
                InventoryQuantity = 80,
                ShipOnWeekends = false,
                MaxBusinessDaysToShip = 15
            }
        };


        public static readonly IEnumerable<Holiday> HolidayData = new List<Holiday>
        {
            new()
            {
                Id =  1,
                Name = "New Year's Day",
                Date = new NodaTime.LocalDate(2021, 1, 1)
            },
            new()
            {
                Id =  2,
                Name = "Birthday of Martin Luther King, Jr.",
                Date = new NodaTime.LocalDate(2021, 1, 20)
            },
             new()
            {
                Id =  3,
                Name = "Presidents' Day",
                Date = new NodaTime.LocalDate(2021, 2, 17)
            },
              new()
            {
                Id =  4,
                Name = "Memorial Day",
                Date = new NodaTime.LocalDate(2021, 5, 25)
            },
               new()
            {
                Id =  5,
                Name = "Independence Day",
                Date = new NodaTime.LocalDate(2021, 7, 4)
            },
                new()
            {
                Id =  6,
                Name = "Labor Day",
                Date = new NodaTime.LocalDate(2021, 9, 7)
            },
                 new()
            {
                Id =  7,
                Name = "Columbus Day",
                Date = new NodaTime.LocalDate(2021, 10, 12)
            },
                  new()
            {
                Id =  8,
                Name = "Veterans Day",
                Date = new NodaTime.LocalDate(2021, 11, 11)
            },
                   new()
            {
                Id =  9,
                Name =  "Thanksgiving Day",
                Date = new NodaTime.LocalDate(2021, 11, 26)
            },
                    new()
            {
                Id =  10,
                Name = "Christmas Day",
                Date = new NodaTime.LocalDate(2021, 12, 25)
            },
        };
    }
}