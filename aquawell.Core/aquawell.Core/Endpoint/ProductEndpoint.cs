namespace aquawell.Core.Endpoint;

public static class ProductEndpoint
{
    public static void MapProduct(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api", async (HttpContext context) =>
        {
            
        });
    }
}