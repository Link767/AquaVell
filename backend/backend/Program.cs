using backend.Middleware;
using backend.Services;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Регистрируем DBWork как сервис (Singleton для локалки)
            builder.Services.AddSingleton(new DBWork(@"Server=(localdb)\MSSQLLocalDB;Database=TestBD;Trusted_Connection=True;TrustServerCertificate=True;"));
            // Регоаем контроллеры
            builder.Services.AddControllers(); 

            var app = builder.Build();

            //Подключаем Middleware
            app.UseMiddleware<StatusMiddleware>();

            //Маршрутизация 
            app.MapControllers();

            app.Run();
        }
    }
}
