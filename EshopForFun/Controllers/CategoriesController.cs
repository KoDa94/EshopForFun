using Microsoft.AspNetCore.Mvc;
using EshopForFun.Models.RequestModels;
using EshopForFun.Models.ResponseModels;
using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Services;
using EshopForFun.AppLayer.Services.Results;

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
                .Select(cat => new CategoryResponse
                (
                    cat.UniqueCategoryString,
                    cat.Name,
                    cat.Description
                )).ToList();

            return Ok(categories);
        }

        [HttpGet("{categoryCode}")] //TASK: Vrátí danou kategorii s názvem a popisem
        public IActionResult GetCategory([FromRoute] string categoryCode)
        {
            var getCategoryResult = categoryService.GetCategoryByCode(categoryCode);

            return getCategoryResult.Result switch
            {
                
                GetCategoryResult.InvalidCode => BadRequest(new ErrorResponse
                (
                    getCategoryResult.Message!,
                    $"{categoryCode} => INVALID_PRODUCT_CODE"
                )),
                
                GetCategoryResult.NotFound => NotFound(new ErrorResponse
                (
                    getCategoryResult.Message!,
                    $"{categoryCode} => ARTICLE_NOT_FOUND"
                )),

                GetCategoryResult.Success => Ok(new CategoryResponse
                (
                    getCategoryResult.Category!.UniqueCategoryString,
                    getCategoryResult.Category.Name,
                    getCategoryResult.Category.Description
    
                )),

                _ => StatusCode(500)
            };

        }

        [HttpGet("{categoryCode}/products")] //TASK: Vrátí všechny produkty ze zadané kategorie
        public IActionResult GetProductsForCategory([FromRoute] string categoryCode)
        {
            var category = categoryService.GetCategoryByCode(categoryCode);

            if (category.Result == GetCategoryResult.NotFound)
            {
                return NotFound(new ErrorResponse
                (
                    $"Kategorie s kódem {categoryCode} neexistuje",
                    $"{categoryCode} => CATEGORY_NOT_FOUND"
                ));
            }

            var products = categoryService.GetProductsForCategory(category.Category!)
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
        public IActionResult CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var createCategoryResult = categoryService.CreateCategory(request.Name, request.Description);

            return createCategoryResult.Result switch
            {
                CreateCategoryResult.Success => Created($"{createCategoryResult.Message}", new CategoryResponse
                (
                    createCategoryResult.Category!.UniqueCategoryString,
                    createCategoryResult.Category.Name,
                    createCategoryResult.Category.Description
                )),

                CreateCategoryResult.ConflictCategoryWithSameName => Conflict(new ErrorResponse
                (
                    createCategoryResult.Message!,
                    $"{request.Name} => CONFLICT_CATEGORY_WITH_SAME_NAME"
                )),
                _ => StatusCode(500)
            };
        }

        [HttpDelete("{categoryCode}")] //TASK: smaže kategorii
        public IActionResult DeleteCategory([FromRoute] string categoryCode)
        {
            var deleteCategoryResult = categoryService.DeleteCategory(categoryCode);

            return deleteCategoryResult.Result switch
            {
                DeleteCategoryResult.Deleted => NoContent(),
                DeleteCategoryResult.NotFound => NotFound(new ErrorResponse
                (
                    $"{deleteCategoryResult.Message}",
                    $"{categoryCode} => NOT_FOUND"
                )),
                DeleteCategoryResult.HasProducts => Conflict(new ErrorResponse
                (
                    $"{deleteCategoryResult.Message}",
                    $"{categoryCode} => HAS_PRODUCTS"
                )),
                _ => StatusCode(500)
            };
        }
        
    }
}
