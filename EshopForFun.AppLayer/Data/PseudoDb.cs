using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services.Results;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace EshopForFun.AppLayer.Data
{
    public static class PseudoDb
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
                    categoryProducts.Add(new Product(productId, $"PRO-{productId}", $"Product no. {productId}", $"Product {productId} from Category {_categoriesNames[i]}", new Random().Next(1, 650), categoryId, false));
                    productId++;
                }

                var category = new Category
                {
                    CategoryId = categoryId,
                    UniqueCategoryString = $"CAT-{categoryId}",
                    Name = _categoriesNames[i],
                    Description = _categoriesDescription[i],
                    Products = categoryProducts,
                    IsRemoved = false
                };
                
                Categories.Add(category);
                categoryId++;
            }
        }

        public static Category AddCategory(string categoryName, string description)
        {
            var newCategoryId = Categories.Count == 0 ? 1 : Categories.Max(d => d.CategoryId) + 1;
            var categoryCode = $"CAT-{newCategoryId}";

            var category = new Category
            {
                CategoryId = newCategoryId,
                UniqueCategoryString = categoryCode,
                Name = categoryName,
                Description = description,
                Products = [],
                IsRemoved = false
            };
            Categories.Add(category);

            return category;
        }

        public static bool IsUniqueCategory(string categoryCode)
        {
            var matches = Categories.Where(cat => cat.UniqueCategoryString == categoryCode).Take(2).ToList(); // nemusí procházet celou kolekci, jakmile narazí na 2 stejné kódy, je jasné, že je unikátnost porušena

            if (matches.Count != 1)
            {
                return false;
            }

            return true;
        }

        public static bool CategoryExistsByName(string categoryName)
        {
            return Categories.Any(cat => cat.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase) && !cat.IsRemoved);
        }

        public static bool HasCategoryProducts(string categoryCode)
        {
            var category = Categories.SingleOrDefault(cat => cat.UniqueCategoryString == categoryCode && !cat.IsRemoved);

            if (category is not null) 
            {
                return category.Products.Any(pro => !pro.IsRemoved);
            }

            return false;
        }

        public static List<Category> GetCategories()
        {
            return Categories.Where(cat => !cat.IsRemoved).ToList();
        }

        public static Category? GetCategory(string categoryCode)
        {
            return Categories.SingleOrDefault(cat => cat.UniqueCategoryString == categoryCode && !cat.IsRemoved);
        }

        public static List<Product> GetProductsForCategory(Category category)
        {
            return category
                .Products.Where(pro => !pro.IsRemoved).ToList();
        }

        public static Product AddProduct(string name, string description, decimal price, string categoryCode)
        {
            var category = Categories.Single(cat => cat.UniqueCategoryString == categoryCode);

            var categoryId = Categories.Where(cat => cat.UniqueCategoryString == categoryCode)
                .Select(cat => cat.CategoryId).Single();

            var newProductId = Products.Count == 0 ? 1 : Products.Max(d => d.ProductId) + 1;
            var productCode = $"PRO-{newProductId}";

            var product = new Product(newProductId, productCode, name, description, price, category.CategoryId, false);

            category.Products.Add(product);

            return product;
        }

        public static bool RemoveCategory(string categoryCode)
        {
            var category = Categories.SingleOrDefault(cat => cat.UniqueCategoryString == categoryCode && !cat.IsRemoved);

            if (category is not null)
            {
                category.IsRemoved = true;

                return true;
            }

            return false;
        }
        public static Product? GetProduct(string productCode)
        {
            return Products.SingleOrDefault(pro => pro.UniqueProductString == productCode && !pro.IsRemoved);
        }

        public static bool RemoveProduct(string productCode)
        {
            foreach (var category in Categories)
            {
                var product = category.Products.SingleOrDefault(pro => pro.UniqueProductString == productCode && !pro.IsRemoved);

                if (product is null) { continue; }

                product.IsRemoved = true;
                return true;
            }

            return false;
        }
        public static Product? UpdateProduct(string productCode, string name, string description, decimal price)
        {
            foreach (var category in Categories)
            {
                var product = category.Products.SingleOrDefault(pro => pro.UniqueProductString == productCode && !pro.IsRemoved);

                if (product is null) { continue; }

                product.Name = name;
                product.Description = description;
                product.Price = price;

                return product;
            }

            return null;
        }

        public static Product? PatchProduct(string productCode, string? name, string? description, decimal? price)
        {
            foreach (var category in Categories)
            {
                var product = category.Products.SingleOrDefault(pro => pro.UniqueProductString == productCode && !pro.IsRemoved);

                if (product is null) { continue; }

                if (name is not null)
                {
                    product.Name = name;
                }

                if (description is not null)
                {
                    product.Description = description;
                }

                if (price is not null)
                {
                    product.Price = price.Value;
                }

                return product;
            }

            return null;
        }
    }
}

