using Bekend.Data.Models;
using Bekend.Data.RequestDataBase;

namespace Bekend.Core.Controllers;

public class AddOrderController
{
    public async Task<bool> AddOrder(HttpRequest request, HttpResponse response)
    {
        Order?  order = await request.ReadFromJsonAsync<Order>();;
        if (order == null)
        {
            response.StatusCode = 401;
            await response.WriteAsync("Invalid  request");
            return false;
        }
        AddOrderRequest addOrderRequest = new AddOrderRequest();
        if (await addOrderRequest.AddOrderAsunc(order.Name, order.Email, order.TelNum))
        {
            response.StatusCode = 201;
            await response.WriteAsync("Order Added");
            return true;
        }
        response.StatusCode = 403;
        return false;
    }
}