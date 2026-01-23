namespace EshopForFun.AppLayer.Models
{
    public record Category
    {
        public int CategoryId { get; init; }
        public string UniqueCategoryString { get; init; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Product> Products { get; init; } = new();
        public bool IsRemoved { get; set; }
    }
}
