using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services
{
    internal class ProductService : IProductService
    {
        public Product? GetProductByCode(string code)
        {
            return PseudoDb.Products.FirstOrDefault(pro => pro.UniqueProductString == code);
        }

        public Product? CreateProduct(string name, string description, decimal price, string categoryCode)
        {
            if (PseudoDb.Categories.Any(cat => cat.UniqueCategoryString == categoryCode))
            {
                var newProduct = PseudoDb.AddProduct(name, description, price, categoryCode);

                return newProduct;
            }

            return null;
        }
    }
}
