using System.ComponentModel.DataAnnotations;

namespace EshopForFun.Models.RequestModels
{
    public class PatchProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    };
}
