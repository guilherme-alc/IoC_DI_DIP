using DependencyStore.Repositories;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services;
using DependencyStore.Services.Interfaces;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddScoped(provider =>
    new SqlConnection("CONN_STRING"));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<ICalculateOrderService, CalculateOrderService>();
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

app.MapControllers();

app.Run();