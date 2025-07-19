using DependencyStore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddSqlConnection("CONN_STRING");
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

app.MapControllers();

app.Run();