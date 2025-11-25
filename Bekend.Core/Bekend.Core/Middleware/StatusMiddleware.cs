namespace Bekend.Core.Middleware;

public class StatusMiddleware
{
    readonly RequestDelegate _next;
    public StatusMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
        switch (context.Response.StatusCode)
        {
            case 404:
                await context.Response.WriteAsync("Not Found");
                break;
            case 403:
                await context.Response.WriteAsync("Access Denied");
                break;
            case 500:
                await context.Response.WriteAsync("Internal Server Error");
                break;
            default:
                //тут вывоз сдедующего Middleware
                await context.Response.WriteAsync("OK");
                break;
        }
    }
}