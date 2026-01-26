using EshopForFun.AppLayer.Models;

namespace EshopForFun.AppLayer.Services.Results
{
    public enum GetProductsResult
    {
        Success,
        NoProduct,
        Category
    }
    public record GetProductsResponse
    (
        GetProductsResult Result,
        List<Product> Products,
        string? Message
    );
    
}
