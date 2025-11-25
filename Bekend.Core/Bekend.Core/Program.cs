using Bekend.Core.Controllers;
using Bekend.Core.Endpoints;
using Bekend.Core.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
var app = builder.Build();

app.UseMiddleware<StatusMiddleware>();

app.MapOrders();
app.Run();