using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Repositories
{
    public interface IProductRepository
    {
      
        public Product? GetProduct(string code);

        bool CanCreateProductInCategory(string categoryCode);

        public Product? CreateProduct(string productName, string description, decimal price, string categoryCody);

        public Product? UpdateProduct(string productCode, string name, string description, decimal price);

        public bool PatchProduct(string productCode, string? name, string? description, decimal? price);

        public bool DeleteProduct(string productCode);
    }
}
