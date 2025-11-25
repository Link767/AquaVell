using Bekend.Core.Controllers;

namespace Bekend.Core.Endpoints;

public static class OrderEndpoint
{
    public static void MapOrders(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/orders", async (HttpRequest request, HttpResponse response) =>
        {
            await new AddOrderController().AddOrder(request, response);
        });
    }
}