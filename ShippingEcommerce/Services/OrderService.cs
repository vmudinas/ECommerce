using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShippingEcommerce.Data;
using ShippingEcommerce.Exceptions;
using ShippingEcommerce.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShippingEcommerce.Models;
using System;
using System.Linq;
using NodaTime;
using System.Collections.Generic;
using NodaTime.Extensions;
using ShippingEcommerce.Data.Entities;

namespace ShippingEcommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        private readonly List<Holiday> _holidays;


        public OrderService(DataContext context, IMapper mapper, ILogger<OrderService> logger,
            IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _holidays = _context.Holidays.ToList();
        }

        public async Task<PagedList<ProductListItem>> SearchProducts(ProductSearchParams searchParams)
        {
            var orderPredicate = _context.Products.AsNoTracking();

            var projectedOrder = orderPredicate.ProjectTo<ProductListItem>(_mapper.ConfigurationProvider);

            var clock = SystemClock.Instance;
            var zoned = clock.InUtc();

            var pagedList = await PagedList<ProductListItem>.CreateAsync(projectedOrder, searchParams.PageNumber, searchParams.PageSize);

            foreach (var value in pagedList)
            {
                value.ExpectedShipDate = CalculateExpextedShippingDate(value, searchParams.OrderDate ?? zoned.GetCurrentDate());

            }

            return pagedList;
        }

        public LocalDate CalculateExpextedShippingDate(ProductListItem product, LocalDate orderDate)
        {
            if (product.ShipOnWeekends)
            {
                if (product.MaxBusinessDaysToShip < 1)
                {
                    return orderDate;
                }

                return orderDate.PlusDays(product.MaxBusinessDaysToShip - 1 + CountHolidays(product.MaxBusinessDaysToShip, orderDate));

                
            }
            else if (!product.ShipOnWeekends)
            {
                orderDate = CountDays(product.MaxBusinessDaysToShip, orderDate);
            }

            return orderDate;
        }

        private int CountHolidays(int maxBusinessDaysToShip, LocalDate orderDate)
        {
            var intHolidays = 0;

            for (int i = maxBusinessDaysToShip; i >= 1;)
            {
                if (_holidays.Any(x => x.Date == orderDate))
                {
                    intHolidays++;
                }
               
                orderDate = orderDate.PlusDays(1);
                i--;
            }

            return intHolidays;
        }

        private LocalDate CountDays(int maxBusinessDaysToShip, LocalDate orderDate)
        {
            for (int i = maxBusinessDaysToShip; i > 1;)
            {
                orderDate = orderDate.PlusDays(1);

                if (orderDate.DayOfWeek == IsoDayOfWeek.Saturday || orderDate.DayOfWeek == IsoDayOfWeek.Sunday || _holidays.Any(x => x.Date == orderDate))
                {
                    i++;
                }

                i--;

                
            }

            return orderDate;
        }

    }
}