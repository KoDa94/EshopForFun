using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services.Results;

namespace EshopForFun.AppLayer.Services
{
    public interface IProductService
    {
        public GetProductResponse GetProduct(string? productCode);

        public CreateProductResponse CreateProduct(string name, string description, decimal price, string categoryCode);

        public GetProductResponse FullUpdateProduct(string productCode, string name, string description, decimal price);

        public DeleteProductResponse DeleteProduct(string productCode);
            
        public GetProductResponse PatchProduct(string productCode, string? name, string? description, decimal? price);
    }
}
