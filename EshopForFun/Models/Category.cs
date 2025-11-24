namespace EshopForFun.Models
{
    public class Category
    {
        public int CategoryId { get; private set; }
        public string UniqueCategoryString { get; private set; }
        public string Name { get;  private set; }
        public string Description { get; private set; }

        public Category(int categoryId, string uniqueCategoryString, string name, string description)
        {
            CategoryId = categoryId;
            UniqueCategoryString = uniqueCategoryString;
            Name = name;
            Description = description;
        }
    }
}
