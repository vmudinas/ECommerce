using NodaTime;
using System;

namespace ShippingEcommerce.Models
{
    public class ProductListItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int InventoryQuantity { get; set; }

        public bool ShipOnWeekends { get; set; }

        public int MaxBusinessDaysToShip { get; set; }

        public LocalDate ExpectedShipDate { get; set; }


    }
}
