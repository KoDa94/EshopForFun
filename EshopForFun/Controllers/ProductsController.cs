using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EshopForFun.Data;
using EshopForFun.Models;

namespace EshopForFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = PseudoDb.Products;
            return Ok(products);
        }
    }
}
