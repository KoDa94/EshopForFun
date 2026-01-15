using System.ComponentModel.DataAnnotations;

namespace EshopForFun.Models.RequestModels
{
    public record CreateProductRequest
    (
        [Required(ErrorMessage = "Název produktu je povinný")]
        string Name,

        [Required(ErrorMessage = "Popis produktu je povinný")]
        string Description,

        [Required(ErrorMessage = "Cena produktu je povinná")]
        decimal Price,

        [Required(ErrorMessage = "Je nutné zadat kód kategorie, kam bych to měl jinak umístit?")]
        string CategoryCode

    );
}
