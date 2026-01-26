using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services.Results
{
    public enum DeleteProductResult
    {
        Deleted,
        NotFound
    }

    public record DeleteProductResponse
    (
        DeleteProductResult Result,
        string? Message
    );
}
