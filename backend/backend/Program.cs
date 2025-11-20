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
            //Запускаем CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            //Используем CORS
            app.UseCors();

            //Подключаем Middleware
            app.UseMiddleware<StatusMiddleware>();

            //Маршрутизация 
            app.MapControllers();

            app.Run();
        }
    }
}
