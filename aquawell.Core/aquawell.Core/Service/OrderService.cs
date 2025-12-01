using aquawell.Core.Dto;
using aquawell.Core.Service.Interfaces;
using aquawell.Data.Postgresql;

namespace aquawell.Core.Service;

public class OrderService :  IOrderService
{
    private  readonly RequestDB _requestDB;
    
    public OrderService(RequestDB requestDB)
    {
        _requestDB = requestDB;
    }

    public async Task PastOrder(string clientName, string clientMail, string clientPhone)
    {
        await _requestDB.PastOrders(clientName, clientMail, clientPhone);
    }
}