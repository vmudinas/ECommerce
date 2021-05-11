using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShippingEcommerce.Data;
using ShippingEcommerce.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using ShippingEcommerce.MapperProfiles;

namespace ShippingEcommerce.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(builder =>
            {
                builder.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
                builder.JsonSerializerOptions.AllowTrailingCommas = true;
                builder.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));            
                builder.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                builder.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("CommerceConnection"), builder =>
                {
                    builder.MigrationsAssembly(typeof(DataContext).GetTypeInfo().Assembly.GetName().Name);
                    builder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                    builder.UseNodaTime();
                });
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            
            return services;
        }
    }
}