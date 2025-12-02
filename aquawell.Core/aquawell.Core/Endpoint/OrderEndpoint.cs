using aquawell.Core.Dto;
using aquawell.Core.Service.Interfaces;

namespace aquawell.Core.Endpoint;

public static class OrderEndpoint
{
    public static void MapOrder(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/order", async (HttpContext context, IOrderService orderService) =>
        {
            OrderDto? orderDto = await context.Request.ReadFromJsonAsync<OrderDto>();
            if (orderDto == null)
                context.Response.StatusCode = 400;
            
            await orderService.PastOrder(orderDto.Name, orderDto.Telnum, orderDto.Email);
            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync(new {success = true});
        });
    }
}