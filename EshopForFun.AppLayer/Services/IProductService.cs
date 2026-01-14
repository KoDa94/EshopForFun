using EshopForFun.AppLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopForFun.AppLayer.Services
{
    public interface IProductService
    {
        public Product? GetProductByCode(string code);
    }
}
