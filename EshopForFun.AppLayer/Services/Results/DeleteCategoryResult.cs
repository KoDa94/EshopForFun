using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services.Results
{
    public enum DeleteCategoryResult
    {
        Deleted,
        NotFound,
        HasProducts
    }

    public record DeleteCategoryResponse
    (
       DeleteCategoryResult Result,
       string? Message
    );
}
