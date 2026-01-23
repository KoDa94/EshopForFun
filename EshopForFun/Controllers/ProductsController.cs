using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Services;
using EshopForFun.AppLayer.Services.Results;
using EshopForFun.Models;
using EshopForFun.Models.RequestModels;
using EshopForFun.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EshopForFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet("{productCode}")]
        public IActionResult GetProductByCode([FromRoute] string? productCode) // vrací produkt podle produktového kódu
        {
            var getProductResult = productService.GetProduct(productCode);

            return getProductResult.Result switch
            {
                GetProductResult.InvalidCode => BadRequest(new ErrorResponse
                (
                    getProductResult.Message!,
                    $"{productCode} => INVALID_PRODUCT_CODE"
                )),
                GetProductResult.NotFound => NotFound(new ErrorResponse
                (
                    getProductResult.Message!,
                    $"{productCode} => ARTICLE_NOT_FOUND"
                )),

                GetProductResult.Success =>
                (
                    Ok(new ProductResponse(
                        getProductResult.Product!.UniqueProductString,
                        getProductResult.Product.Name,
                        getProductResult.Product.Description,
                        getProductResult.Product.Price
                    ))
                ),
                _ => StatusCode(500)
            };
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request) //vytvoření nového produktu
        {
            var createProductResult = productService.CreateProduct(request.Name, request.Description, request.Price, request.CategoryCode);
           
            return createProductResult.Result switch
            {
                CreateProductResult.NotFoundCategoryForProduct => BadRequest(new ErrorResponse
                (
                    createProductResult.Message!,
                    $"{request.CategoryCode} => CATEGORY_FOR_PRODUCT_NOT_FOUND"
                )),

                CreateProductResult.Success =>
                (
                    Created($"api/products/{createProductResult.Product!.UniqueProductString}" , new ProductResponse(
                        createProductResult.Product.UniqueProductString,
                        createProductResult.Product.Name,
                        createProductResult.Product.Description,
                        createProductResult.Product.Price
                    ))
                ),
                _ => StatusCode(500)
            };
        }

        [HttpPut("{productCode}")]
        public IActionResult UpdateProduct([FromRoute] string productCode, [FromBody] UpdateProductRequest request) //kompletní update celého produktu
        {
            var updateProductResult = productService.FullUpdateProduct(productCode, request.Name, request.Description, request.Price);
            
            return updateProductResult.Result switch
            {
                GetProductResult.Success => Ok(new ProductResponse(
                    updateProductResult.Product!.UniqueProductString,
                    updateProductResult.Product.Name,
                    updateProductResult.Product.Description,
                    updateProductResult.Product.Price
                )),
                GetProductResult.NotFound => NotFound(new ErrorResponse
                (
                    updateProductResult.Message!,
                    $"{productCode} => NOT_FOUND"
                )),
                _ => StatusCode(500)
            };
        }

        [HttpPatch("{productCode}")]
        public IActionResult PatchProduct([FromRoute] string productCode, [FromBody] PatchProductRequest request)
        {
            var patchProductResult = productService.PatchProduct(productCode, request.Name, request.Description, request.Price);
       
            return patchProductResult.Result switch
            {
                GetProductResult.Success => Ok(new ProductResponse(
                    patchProductResult.Product!.UniqueProductString,
                    patchProductResult.Product.Name,
                    patchProductResult.Product.Description,
                    patchProductResult.Product.Price
                )),
                GetProductResult.NotFound => NotFound(new ErrorResponse
                (
                    $"Produkt nebyl nalezen",
                    $"{productCode} => NOT_FOUND"
                )),
                _ => StatusCode(500)
            };
        }

        [HttpDelete("{productCode}")] //Task: maže produkt
        public IActionResult DeleteProduct([FromRoute] string productCode)
        {
            var deleteProductResult = productService.DeleteProduct(productCode);

            return deleteProductResult.Result switch
            {
                DeleteProductResult.Deleted => NoContent(),
                DeleteProductResult.NotFound => NotFound(new ErrorResponse
                (
                    deleteProductResult.Message!,
                    $"{productCode} => NOT_FOUND"
                )),
                _ => StatusCode(500)
            };
        }
    }
}
