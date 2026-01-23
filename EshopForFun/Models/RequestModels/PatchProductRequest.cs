using System.ComponentModel.DataAnnotations;

namespace EshopForFun.Models.RequestModels
{
    public record PatchProductRequest
    (
        string? Name,
        string? Description,
        decimal? Price
    );
}
