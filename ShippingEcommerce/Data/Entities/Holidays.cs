using NodaTime;
using System.ComponentModel.DataAnnotations;

namespace ShippingEcommerce.Data.Entities
{
    public class Holiday
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public LocalDate Date { get; set; }
    }
}
