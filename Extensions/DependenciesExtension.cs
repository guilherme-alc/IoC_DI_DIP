using DependencyStore.Repositories;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services;
using DependencyStore.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyStore.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddSqlConnection(this IServiceCollection services, string connectionString)
        {
            services.AddScoped(provider =>
                new SqlConnection("CONN_STRING"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.TryAddTransient<ICustomerRepository, CustomerRepository>();
            services.TryAddScoped<IProductRepository, ProductRepository>();
            services.TryAddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.TryAddTransient<IDeliveryService, DeliveryService>();
            services.TryAddScoped<ICalculateOrderService, CalculateOrderService>();
            services.TryAddScoped<IProductService, ProductService>();
            services.TryAddScoped<IOrderService, OrderService>();
        }
    }
}
