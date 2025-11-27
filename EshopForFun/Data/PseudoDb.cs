using EshopForFun.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace EshopForFun.Data
{
    public static class PseudoDb
    {
        private static string[] _categoriesNames = { "books", "elektronics", "medicines", "cars", "musical Instruments" };
        private static string[] _categoriesDescription = { "Many books to read, just choose", "New TV? No problem!", "Out of pills? We are the pill champions", "Used car kaput? Try ours", "You want be like Cunts´n´Coke? Then buy a new quitar!" };
        public static List<Product> Products { get; set; } = [];
        public static List<Category> Categories { get; set; } = [];

        static PseudoDb()
        {
            var productId = 1;
            var categoryId = 1;

            for (int i = 0; i < _categoriesNames.Length; i++)
            {
                Categories.Add(new Category(categoryId, $"CAT-{categoryId}", _categoriesNames[i], _categoriesDescription[i]));
                categoryId++;
                
                for (int j = 0; j < 5; j++)
                {
                    Products.Add(new Product(productId, $"PRO-{productId}", $"Product no. {productId}", $"Product {productId} from Category {Categories[i].Name}", new Random().Next(1, 650), Categories[i].CategoryId));
                    productId++;
                }
            }
        }

        public static Category AddCategory(string name, string description)
        {
            var newCategoryId = Categories.Count == 0 ? 1 : Categories.Max(d => d.CategoryId) + 1;
            var code = $"CAT-{newCategoryId}";

            var category = new Category(newCategoryId, code, name, description);
            Categories.Add(category);

            return category;
        }

    }
}

