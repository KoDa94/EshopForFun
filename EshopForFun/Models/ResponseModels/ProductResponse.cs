namespace EshopForFun.Models.ResponseModels
{
    public record ProductResponse
    (
        string? ProductCode,
        string? Name,
        string? Description,
        decimal? Price
    );

    
}
