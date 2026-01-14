using EshopForFun.AppLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category? GetCategoryByCode(string code);

        public List<Product> GetProductsByCategoryCode(string categoryCode);
        public Category? CreateCategory(string name, string description);
    }
}
