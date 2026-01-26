using EshopForFun.AppLayer.Models;

namespace EshopForFun.AppLayer.Services.Results
{
    public enum GetProductResult
    {
        Success,
        NotFound,
        InvalidCode
    }

    public record GetProductResponse
    (
        GetProductResult Result,
        Product? Product,
        string? Message
    );

}
