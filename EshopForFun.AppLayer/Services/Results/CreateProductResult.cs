using EshopForFun.AppLayer.Models;


namespace EshopForFun.AppLayer.Services.Results
{
    public enum CreateProductResult
    {
        Success,
        NotFoundCategoryForProduct
    }

    public record CreateProductResponse
    (
        CreateProductResult Result,
        Product? Product,
        string? Message
    );

}
