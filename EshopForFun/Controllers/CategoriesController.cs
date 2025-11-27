using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EshopForFun.Models.Response;
using EshopForFun.Data;
using EshopForFun.Models.RequestModels;
using EshopForFun.Models.ResponseModels;

namespace EshopForFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCategories() //TASK: vrátí všechny kategorie
        {
            var categories = PseudoDb.Categories.
                Select(c => new CategoryResponse
                (
                    c.UniqueCategoryString,
                    c.Name,
                    c.Description
                )).ToList();

            return Ok(categories);
        }

        [HttpGet("{code}")] //TASK: Vrátí danou kategorii s názvem a popisem
        public IActionResult GetCategory([FromRoute]string code)
        {
            var category = PseudoDb.Categories.
                FirstOrDefault(cat => cat.UniqueCategoryString == code);
            if (category is null)
            {
                return NotFound(new ErrorResponse
                (
                    $"Kategorie s kódem {code} neexistuje",
                    $"{code} => CATEGORY_NOT_FOUND"
                ));
            }
            return Ok(new CategoryResponse
            (
                category.UniqueCategoryString,
                category.Name,
                category.Description
            ));
        }

        [HttpGet("{code}/articles")] //TASK: Vrátí všechny produkty ze zadané kategorie
        public IActionResult GetProductArticlesFromCategory([FromRoute] string code)
        {
            var category = PseudoDb.Categories
                .FirstOrDefault(cat => cat.UniqueCategoryString == code);

            if (category is null)
            {
                return NotFound(new ErrorResponse
                (
                    $"Kategorie s kódem {code} neexistuje",
                    $"{code} => CATEGORY_NOT_FOUND"
                ));
            }

            var products = PseudoDb.Products
                .Where(pro => pro.CategoryId == category?.CategoryId)
                .Select(p => new ProductResponse
                (
                    p.UniqueProductString,
                    p.Name,
                    p.Description,
                    p.Price
                ))
                .ToList();
            
            return Ok(products);
        }

        
        [HttpPost] //TASK: zakládá novou kategorii 
        public IActionResult CreateCategory([FromBody]CreateCategoryRequest request)
        {
            if (request.Name is null || request.Description is null)
            {
                return BadRequest("Tak tam snad něco napíšeš, ne?");
            }

            if (PseudoDb.Categories
                    .Any(c => c.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError(
                    "name",
                    $"Kategorie s názvem {request.Name} již existuje"
                );

                return ValidationProblem(ModelState);
            }

            var newCategory = PseudoDb.AddCategory(request.Name, request.Description);

            var response = new CategoryResponse(
                newCategory.UniqueCategoryString,
                newCategory.Name,
                newCategory.Description
            );

            return Created($"api/categories/",response);
        }
        
    }
}
