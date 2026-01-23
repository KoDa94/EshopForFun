using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Repositories;
using EshopForFun.AppLayer.Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EshopForFun.Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            return PseudoDb.GetCategories();
        }

        public Category? GetCategoryByCode(string categoryCode)
        {
            return PseudoDb.GetCategory(categoryCode); 
        }

        public List<Product> GetProductsForCategory(Category Category)
        {
            return PseudoDb.GetProductsForCategory(Category);
        }

        public Category CreateCategory(string name, string description)
        {
            return PseudoDb.AddCategory(name, description);
        }

        public bool DeleteCategory(string categoryCode)
        {
            return PseudoDb.RemoveCategory(categoryCode);
        }

        public bool CategoryExistsByName(string categoryName)
        {
            return PseudoDb.CategoryExistsByName(categoryName);
        }

        public bool HasCategoryProducts(string categoryCode)
        {
            return PseudoDb.HasCategoryProducts(categoryCode);
        }
    }
}
