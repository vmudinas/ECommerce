using System.Collections.Immutable;
using System.Linq;
using AutoMapper;
using ShippingEcommerce.Data.Entities;
using ShippingEcommerce.Models;

namespace ShippingEcommerce.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
   
            CreateMap<Product, ProductListItem>().ReverseMap();

        }
    }
}