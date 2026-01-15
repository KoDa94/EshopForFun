using EshopForFun.AppLayer.Models;

namespace EshopForFun.AppLayer.Data
{
    internal static class PseudoDb
    {
        private static string[] _categoriesNames = { "books", "elektronics", "medicines", "cars", "musical Instruments" };
        private static string[] _categoriesDescription = { "Many books to read, just choose", "New TV? No problem!", "Out of pills? We are the pill champions", "Used car kaput? Try ours", "You want be like Cunts´n´Coke? Then buy a new quitar!" };
        public static List<Product> Products => Categories.SelectMany(x => x.Products).ToList();
        public static List<Category> Categories { get; set; } = [];

        static PseudoDb()
        {
            var productId = 1;
            var categoryId = 1;

            for (int i = 0; i < _categoriesNames.Length; i++)
            {
                List<Product> categoryProducts = new();

                for (int j = 0; j < 5; j++)
                {
                    categoryProducts.Add(new Product(productId, $"PRO-{productId}", $"Product no. {productId}", $"Product {productId} from Category {_categoriesNames[i]}", new Random().Next(1, 650), categoryId));
                    productId++;
                }

                var category = new Category(categoryId, $"CAT-{categoryId}", _categoriesNames[i], _categoriesDescription[i], categoryProducts);
                Categories.Add(category);
                categoryId++;                
            }
        }

        public static Category AddCategory(string name, string description)
        {
            var newCategoryId = Categories.Count == 0 ? 1 : Categories.Max(d => d.CategoryId) + 1;
            var categoryCode = $"CAT-{newCategoryId}";

            var category = new Category(newCategoryId, categoryCode, name, description, []);
            Categories.Add(category);

            return category;
        }

        public static Product AddProduct(string name, string description, decimal price, string categoryCode )
        {
            var category = Categories.Single(cat => cat.UniqueCategoryString == categoryCode);

            var categoryId = Categories.Where(cat => cat.UniqueCategoryString == categoryCode)
                .Select(cat => cat.CategoryId).Single();
            
            var newProductId = Products.Count == 0 ? 1 : Products.Max(d => d.Id) + 1;
            var productCode = $"PRO-{newProductId}";

            var product = new Product(newProductId, productCode, name, description, price, category.CategoryId);
            
            category.Products.Add(product);

            return product;
        }

    }
}

