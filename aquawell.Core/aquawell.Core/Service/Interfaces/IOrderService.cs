using aquawell.Core.Dto;

namespace aquawell.Core.Service.Interfaces;

public interface IOrderService
{
    public Task PastOrder(string clientName, string clientMail, string clientPhone);
}