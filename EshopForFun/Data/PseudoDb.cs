using EshopForFun.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace EshopForFun.Data
{
    public static class PseudoDb
    {
        private static string[] CategoriesNames = { "Books",  "Elektronics", "Medicines", "Cars", "Musical Instruments"};
        private static string[] CategoriesDescription = { "Many books to read, just choose", "New TV? No problem!", "Out of pills? We are the pill champions", "Used car kaput? Try ours", "You want be like Cunts´n´Coke? Then buy a new quitar!" };
        public static int _ProductId { get; private set; } = 1;
        public static int _CategoryId {  get; private set; } = 1;
        public static List<Product> Products { get; set; }
        public static List<Category> Categories { get; set; }

        static PseudoDb()
        {
            Categories = new List<Category>();
            Products = new List<Product>();

            for (int i = 0; i < CategoriesNames.Length; i++)
            {
                Categories.Add(new Category(_CategoryId, $"CAT-{_CategoryId}", CategoriesNames[i], CategoriesDescription[i]));
                _CategoryId++;
            }

            for (int i = 0; i < CategoriesNames.Length; i++)
            { 
                for (int j = 0; j < 5; j++)
                {
                    Products.Add(new Product(_ProductId, $"PRO-{_ProductId}", $"Product no. {_ProductId}", $"Product {_ProductId} from Category {Categories[i].Name}", new Random().Next(1, 650), Categories[i].CategoryId));
                    _ProductId++;
                }    
            }
        }

    }
}

