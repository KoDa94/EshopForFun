using EshopForFun.AppLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();

        Category? GetCategoryByCode(string code);

        List<Product> GetProductsForCategory(Category Category);

        Category CreateCategory(string name, string description);

        bool DeleteCategory(string categoryCode);

        bool CategoryExistsByName(string categoryName);

        public bool HasCategoryProducts(string categoryCode);
    }
}
