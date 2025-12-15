using aquawell.Core.Dto;
using aquawell.Core.Service.Interfaces;
using aquawell.Data.Postgresql;
using aquawell.Data.Postgresql.Models;

namespace aquawell.Core.Service;

public class ProductService : IProductService
{
    private readonly RequestDB _requestDb;
    public ProductService(RequestDB requestDb) => _requestDb = requestDb;

    public async Task<MinProductDto?> GetMinProduct()
    {
        MinProductModel minProductModel = await _requestDb.GetMinProduct();
        if (minProductModel == null)
            return null;
        return new MinProductDto
        {
            ProductName  = minProductModel.ProductName,
            ProductPrice = minProductModel.ProductPrice,
        };
    }

    public async Task<FullProductDto?> GetFullProduct(string productName)
    {
        ProductModel productModel = await _requestDb.GetProduct(productName);
        return new FullProductDto
        {
            ProductName = productModel.ProductName,
            ProductWidth = productModel.ProductWidth,
            ProductLength =  productModel.ProductLength,
            ProductDepth = productModel.ProductDepth,
            ProductDescription = productModel.ProductDescription,
            ProductPrice = productModel.ProductPrice,
            
        };
    }
}