using Microsoft.AspNetCore.Mvc;
using ShippingEcommerce.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShippingEcommerce.Extensions;
using ShippingEcommerce.Models;

namespace ShippingEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public InventoryController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductListItem>>> SearchOrders([FromQuery] ProductSearchParams searchParams)
        {
            var products = await _orderService.SearchProducts(searchParams);
            Response.AddPaginationHeader(products.CurrentPage, products.PageSize, products.TotalCount, products.TotalPages);
            return Ok(products);
        }

    }
}
