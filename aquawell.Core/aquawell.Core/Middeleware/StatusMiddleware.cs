namespace aquawell.Core.Middeleware;

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
        Console.WriteLine($"[{DateTime.Now}] {context.Request.Path} {context.Response.StatusCode}]");
    }
}