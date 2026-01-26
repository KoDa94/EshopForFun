using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services.Results
{
    public enum PatchProductResult
    {
        PartialUpdated,
        NegativePrice,
        Error
    }

    public record PatchProductResponse
    (
        PatchProductResult Result,
        string? Message
    );
}
