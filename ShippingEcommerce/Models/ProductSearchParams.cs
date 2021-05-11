using Microsoft.AspNetCore.Mvc;
using NodaTime;
using System;

namespace ShippingEcommerce.Models
{
    public class ProductSearchParams : PaginationParams
    {     

        [FromQuery(Name = "f")]
        public LocalDate? OrderDate { get; set; }

    }

    public class PaginationParams 
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}