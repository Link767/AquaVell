namespace backend.Middleware
{
    public class StatusMiddleware
    {
        readonly RequestDelegate next;
        public StatusMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);
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
}
