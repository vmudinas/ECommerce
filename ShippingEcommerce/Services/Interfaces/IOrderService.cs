using System.Threading.Tasks;
using ShippingEcommerce.Models;
using ShippingEcommerce.Helpers;

namespace ShippingEcommerce.Services
{
    public interface IOrderService
    {
        Task<PagedList<ProductListItem>> SearchProducts(ProductSearchParams searchParams);
    }
}