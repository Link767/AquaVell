using backend.DataBase;
using backend.DataBase.Table;
using backend.Middleware;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.UseMiddleware<OrderMiddleware>();

            app.Run();
        }
    }
}
