using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services;
using EshopForFun.Models;
using EshopForFun.Models.RequestModels;
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

        [HttpPost]
        public IActionResult CreateProduct([FromBody]CreateProductRequest request)
        {
            var newProduct = productService.CreateProduct(request.Name, request.Description, request.Price, request.CategoryCode);

            if (newProduct is null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    $"Nevalidní data pro založení produktu. Chyba nejspíše v kódu kategorie (neexistuje). Ale chápu, že tohle není validní řešení"
                );

                return ValidationProblem(ModelState);
            }

            var response = new ProductResponse(
                newProduct.UniqueProductString,
                newProduct.Name,
                newProduct.Description,
                newProduct.Price
            );

            return Created($"api/products/{newProduct.UniqueProductString}", response );
        }
    }
}
