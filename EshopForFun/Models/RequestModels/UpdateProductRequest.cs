using System.ComponentModel.DataAnnotations;

namespace EshopForFun.Models.RequestModels
{
    public record UpdateProductRequest
    (
        [Required(ErrorMessage = "Změna názvu produktu je povinná")]
        string Name,

        [Required(ErrorMessage = "Popis produktu je povinný")]
        string Description,

        [Required(ErrorMessage = "Cena produktu je povinná")]
        decimal Price
    );
}
