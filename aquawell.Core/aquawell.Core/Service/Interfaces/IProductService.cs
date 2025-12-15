using aquawell.Core.Dto;

namespace aquawell.Core.Service.Interfaces;

public interface IProductService
{
    public Task<MinProductDto?> GetMinProduct();
}