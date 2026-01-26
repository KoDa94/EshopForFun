using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services.Results;
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
        public GetCategoryResponse GetCategoryByCode(string categoryCode);

        public List<Product> GetProductsForCategory(Category Category);
        public CreateCategoryResponse CreateCategory(string name, string description);

        public DeleteCategoryResponse DeleteCategory(string categoryCode);
    }
}
