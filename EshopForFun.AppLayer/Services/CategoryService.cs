using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Repositories;
using EshopForFun.AppLayer.Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services
{
    internal class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
 
        public List<Category> GetAllCategories() //done
        {
            return categoryRepository.GetAllCategories();
        }

        public GetCategoryResponse GetCategoryByCode(string categoryCode) //done
        {
            if(string.IsNullOrWhiteSpace(categoryCode))
            {
                return new(GetCategoryResult.InvalidCode, null, "Neplatný kód kategorie");
            }

            var category = categoryRepository.GetCategoryByCode(categoryCode);

            if (category is null)
            {
                return new(GetCategoryResult.NotFound, null, $"Kategorie s kódem {categoryCode} nebyla nalezena");
            }

            return new(GetCategoryResult.Success, category, null);
        }

        public List<Product> GetProductsForCategory(Category Category) //done
        {
            return categoryRepository.GetProductsForCategory(Category);
        }

        public CreateCategoryResponse CreateCategory(string name, string description) //done
        {
            
            if (!categoryRepository.CategoryExistsByName(name))
            {
                var category = categoryRepository.CreateCategory(name, description);

                return new(CreateCategoryResult.Success, category, $"api/categories/{category.UniqueCategoryString}");
            }

            return new(CreateCategoryResult.ConflictCategoryWithSameName, null, "Konflikt v názvu, kategorie s názvem již existuje");
        }

        public DeleteCategoryResponse DeleteCategory(string categoryCode)  //done (ale mrknout se na soft delete)
        {

            if (categoryRepository.HasCategoryProducts(categoryCode))
            {
                return new(DeleteCategoryResult.HasProducts, "Kategorie nelze smazat, stále obsahuje produkty");
            }

            if (categoryRepository.DeleteCategory(categoryCode))
            {
                return new(DeleteCategoryResult.Deleted, "Kategorie byla úspěšně smazána");
            }

            return new(DeleteCategoryResult.NotFound, "Kategorie, kterou chcete smazat, nebyla nalezena");
        }
    }
}
