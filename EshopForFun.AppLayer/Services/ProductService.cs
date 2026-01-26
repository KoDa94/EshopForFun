using EshopForFun.AppLayer.Data;
using EshopForFun.AppLayer.Models;
using EshopForFun.AppLayer.Repositories;
using EshopForFun.AppLayer.Services.Results;

namespace EshopForFun.AppLayer.Services
{
    internal class ProductService(IProductRepository productRepository) : IProductService
    {
        public GetProductResponse GetProduct(string? productCode)
        {
            if(string.IsNullOrWhiteSpace(productCode))
            {
                return new(GetProductResult.InvalidCode, null, "Neplatný produktový kód");
            }

            var product = productRepository.GetProduct(productCode);

            if (product is null)
            {
                return new(GetProductResult.NotFound, null, $"Produkt s kódem {productCode} neexistuje");
            }

            return new(GetProductResult.Success, product, null);
        }
        
        public CreateProductResponse CreateProduct(string name, string description, decimal price, string categoryCode)
        {
            if (productRepository.CanCreateProductInCategory(categoryCode))
            {
                var newProduct = productRepository.CreateProduct(name, description, price, categoryCode);

                return new(CreateProductResult.Success, newProduct, null);
            }

            return new(CreateProductResult.NotFoundCategoryForProduct, null, "Zboží nelze založit z důvodu chybějící kategorie. Založte prvně kategorii");
        }

        public GetProductResponse FullUpdateProduct(string productCode, string name, string description, decimal price)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                return new(GetProductResult.InvalidCode, null, "Neplatný produktový kód");
            }

            var product = productRepository.UpdateProduct(productCode, name, description, price);

            if (product is null)
            {
                return new(GetProductResult.NotFound, null, "Produkt, který chcete změnit neexistuje");
            }

            return new(GetProductResult.Success, product, "Produkt byl kompletně aktualizován");
        }
        
        public PatchProductResponse PatchProduct(string productCode, string? productName, string? productDescription, decimal? productPrice)
        {
            if (productPrice < 0)
            {
                return new PatchProductResponse(PatchProductResult.NegativePrice, "Cena produktu nesmí být záporná");
            }

            if (productRepository.PatchProduct(productCode, productName, productDescription, productPrice))
            {
                return new PatchProductResponse(PatchProductResult.PartialUpdated, "Produkt byl úspěšně aktualizován");
            }

            return new PatchProductResponse(PatchProductResult.Error, "Nečekaná chyba, jsem kokot");
        }
       
        public DeleteProductResponse DeleteProduct(string productCode)
        {
            if(productRepository.DeleteProduct(productCode))
            {
                return new(DeleteProductResult.Deleted, "Produkt byl smazán");
            }

            return new(DeleteProductResult.NotFound, "Produkt, který chcete smazat nebyl nalezen");
        }

    }
}
