namespace EshopForFun.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string UniqueProductString { get;  set; }
        public string Name { get;  set; }
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Product(int id, string uniqueProductString, string name, string description, decimal price, int categoryId)
        {
            Id = id;
            UniqueProductString = uniqueProductString;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
