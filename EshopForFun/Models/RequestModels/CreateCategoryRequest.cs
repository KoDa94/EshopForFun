using System.ComponentModel.DataAnnotations;

namespace EshopForFun.Models.RequestModels
{
    public record CreateCategoryRequest
    (
        [Required(ErrorMessage = "Název kategorie je povinný")]
        string Name,

        [Required(ErrorMessage = "Popis kategorie je povinný")]
        [MinLength(5, ErrorMessage = "Popis kategorie musí být minimálně 5 znaků")]
        string Description
    );
}
