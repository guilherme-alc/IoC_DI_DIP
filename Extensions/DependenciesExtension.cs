using DependencyStore.Repositories;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services;
using DependencyStore.Services.Interfaces;
using Microsoft.Data.SqlClient;

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
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDeliveryService, DeliveryService>();
            services.AddScoped<ICalculateOrderService, CalculateOrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
