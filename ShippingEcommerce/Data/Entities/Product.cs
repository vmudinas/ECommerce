using System.ComponentModel.DataAnnotations;

namespace ShippingEcommerce.Data.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

         public string ProductName { get; set; }

        public int InventoryQuantity { get; set; }

        public bool ShipOnWeekends { get; set; }

        public int MaxBusinessDaysToShip { get; set; }
    }
}
