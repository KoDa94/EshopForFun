using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services
{
    internal class CategoryService : ICategoryService
    {
        public List<Category> GetAllCategories()
        {
            return PseudoDb.Categories.ToList();
        }

        public Category? GetCategoryByCode(string code)
        {
            return PseudoDb.Categories.FirstOrDefault(cat => cat.UniqueCategoryString == code);
        }

        public List<Product> GetProductsByCategoryCode(string categoryCode)
        {
            return PseudoDb.Categories
                .First(pro => pro.UniqueCategoryString == categoryCode)
                .Products;
        }

        public Category? CreateCategory(string name, string description)
        {
            if (PseudoDb.Categories
               .Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }

            var newCategory = PseudoDb.AddCategory(name, description);

            return newCategory;
        }
    }
}
