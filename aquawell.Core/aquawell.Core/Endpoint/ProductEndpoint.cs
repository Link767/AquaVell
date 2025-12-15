using aquawell.Core.Dto;
using aquawell.Core.Service.Interfaces;

namespace aquawell.Core.Endpoint;

public static class ProductEndpoint
{
    public static void MapProduct(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/product", async (HttpContext context,  IProductService productService) =>
        {
            MinProductDto? productDto = await productService.GetMinProduct();
            if (productDto == null)
                context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(productDto);
        });
        app.MapGet("/api/fullproduct", async (HttpContext context, IProductService productService) =>
        {
            Console.WriteLine(context.Request.Query["productName"]);
            FullProductDto? fullProductDto = await productService.GetFullProduct(context.Request.Query["productName"]);
            if (fullProductDto == null)
                context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(fullProductDto);
        });
    }
}