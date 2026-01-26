using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services.Results;

namespace EshopForFun.AppLayer.Services
{
    public interface IProductService
    {
        GetProductResponse GetProduct(string? productCode);

        CreateProductResponse CreateProduct(string name, string description, decimal price, string categoryCode);

        GetProductResponse FullUpdateProduct(string productCode, string name, string description, decimal price);

        DeleteProductResponse DeleteProduct(string productCode);

        PatchProductResponse PatchProduct(string productCode, string? productName, string? productDescription, decimal? productPrice);
    }
}
