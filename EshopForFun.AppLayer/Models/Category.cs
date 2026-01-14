namespace EshopForFun.AppLayer.Models
{
    public record Category
    (
        int CategoryId,
        string UniqueCategoryString,
        string Name,
        string Description,
        List<Product> Products
    );
}
