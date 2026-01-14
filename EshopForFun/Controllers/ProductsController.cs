using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services;
using EshopForFun.Models;
using EshopForFun.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopForFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet("{code}")]
        public IActionResult GetProductByCode([FromRoute] string code)
        {
            var product = productService.GetProductByCode(code);

            if (product is null)
            {
                return NotFound(new ErrorResponse
                 (
                     $"Zboží s kódem {code} neexistuje!",
                     $"{code} => ARTICLE_NOT_FOUND"
                 ));
            }

            return Ok(new ProductResponse
                (
                    product.UniqueProductString,
                    product.Name,
                    product.Description,
                    product.Price
                ));
        }
    }
}
