using Microsoft.AspNetCore.Mvc;
using EshopForFun.Models.RequestModels;
using EshopForFun.Models.ResponseModels;
using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Services;

namespace EshopForFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase 
    {
        [HttpGet]
        public IActionResult GetAllCategories() //TASK: vrátí všechny kategorie
        {
            var categories = categoryService.GetAllCategories()
                .Select(c => new CategoryResponse
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
            var category = categoryService.GetCategoryByCode(code);

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
        
        [HttpGet("{code}/products")] //TASK: Vrátí všechny produkty ze zadané kategorie
        public IActionResult GetProductsForCategory([FromRoute] string code)
        {
            var category = categoryService.GetCategoryByCode(code);

            if (category is null)
            {
                return NotFound(new ErrorResponse
                (
                    $"Kategorie s kódem {code} neexistuje",
                    $"{code} => CATEGORY_NOT_FOUND"
                ));
            }

            var products = categoryService.GetProductsByCategoryCode(code)
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
            var newCategory = categoryService.CreateCategory(request.Name, request.Description);

            if (newCategory is null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    $"Nevalidní data pro založení kategorie"
                );

                return ValidationProblem(ModelState);
            }
            
            var response = new CategoryResponse(
                newCategory.UniqueCategoryString,
                newCategory.Name,
                newCategory.Description
            );

            return Created($"api/categories/{newCategory.UniqueCategoryString}", response);
        }
        
    }
}
