using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EshopForFun.Models.Response;
using EshopForFun.Data;

namespace EshopForFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<CategoryResponse>> GetAllCategories()
        {
            var categories = PseudoDb.Categories.
                Select(c => new CategoryResponse
                {
                    Code = c.UniqueCategoryString,
                    Name = c.Name,
                    Description = c.Description,
                }).ToList();

            return Ok(categories);
        }
    }
}
