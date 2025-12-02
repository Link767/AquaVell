using aquawell.Core.Endpoint;
using aquawell.Core.Middeleware;
using aquawell.Core.Service;
using aquawell.Core.Service.Interfaces;
using aquawell.Data.Postgresql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

//Service
builder.Services.AddScoped<RequestDB>();
builder.Services.AddScoped<IOrderService, OrderService>();
// Reg CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
//Middleware
app.UseMiddleware<StatusMiddleware>();
//CORS
app.UseCors();
//Endpoint
app.MapOrder();

app.Run();