using backend.DataBase;
using backend.DataBase.Table;

namespace backend.Middleware
{
    public class OrderMiddleware
    {
        private readonly RequestDelegate _next;
        public OrderMiddleware(RequestDelegate _next)
        {
            this._next = _next; 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            var path = request.Path;
            var method = request.Method;
            if (path.StartsWithSegments("/order") && method == "POST")
            {
                var order = await request.ReadFromJsonAsync<Order>(); //Получаем данные с фронта
                Console.WriteLine($"Упал заказ\n Name: {order.Name} \t Email: {order.Email} \t TelNum:{order.TelNum}");

                DBWork dBWork = new DBWork(@"Server=(localdb)\MSSQLLocalDB;Database=TestBD;Trusted_Connection=True;TrustServerCertificate=True;");
                await dBWork.AddOrderAsunc(order.Name, order.Email, order.TelNum);

                //await _next(context);
            }
        }
    }
}
