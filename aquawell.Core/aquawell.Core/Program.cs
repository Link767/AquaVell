using aquawell.Core.Endpoint;
using aquawell.Core.Middeleware;
using aquawell.Core.Service;
using aquawell.Core.Service.Interfaces;
using aquawell.Data.Postgresql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddScoped<RequestDB>();

builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

app.UseMiddleware<StatusMiddleware>();

app.MapOrder();

app.Run();