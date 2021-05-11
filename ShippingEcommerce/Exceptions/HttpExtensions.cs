using System.Text.Json;
using Microsoft.AspNetCore.Http;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using ShippingEcommerce.Helpers;

namespace ShippingEcommerce.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, 
            int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            options.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}