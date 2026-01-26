using EshopForFun.AppLayer.Models;

namespace EshopForFun.AppLayer.Services.Results
{
    public enum GetCategoryResult
    {
        NotFound,
        Success,
        InvalidCode
    }

    public record GetCategoryResponse
    (
        GetCategoryResult Result,
        Category? Category,
        string? Message
    );
}
