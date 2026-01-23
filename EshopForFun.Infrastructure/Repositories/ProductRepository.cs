using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Repositories;
using EshopForFun.AppLayer.Services.Results;

namespace EshopForFun.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        public Product? GetProduct(string productCode)
        {
            return PseudoDb.GetProduct(productCode);
        }
        public bool CanCreateProductInCategory(string categoryCode)
        {
            return PseudoDb.IsUniqueCategory(categoryCode);
        }

        public Product? CreateProduct(string productName, string description, decimal price, string categoryCody)
        {
            return PseudoDb.AddProduct(productName, description, price, categoryCody);
        }

        public Product? UpdateProduct(string productCode, string name, string description, decimal price)
        {
            return PseudoDb.UpdateProduct(productCode, name, description, price);
        }

        public Product? PatchProduct(string productCode, string? name, string? description, decimal? price)
        {
            return PseudoDb.PatchProduct(productCode, name, description, price);
        }

        public bool DeleteProduct(string productCode)
        {
            return PseudoDb.RemoveProduct(productCode);
        }
    }
}
