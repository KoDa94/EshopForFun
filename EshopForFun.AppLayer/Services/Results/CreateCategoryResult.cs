using EshopForFun.AppLayer.Models;

namespace EshopForFun.AppLayer.Services.Results
{
    public enum CreateCategoryResult
    {
        Success,
        ConflictCategoryWithSameName
    }

    public record CreateCategoryResponse
    (
        CreateCategoryResult Result,
        Category? Category,
        string? Message
    );
}
