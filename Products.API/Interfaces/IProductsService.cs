using System.Collections.Generic;
using Products.API.Data.Entities;
using Products.API.Contracts.Requests;

namespace Products.API.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<ProductsEntity> ListProducts(GetRequestFilter filters);
        ProductsEntity FindProduct(int pId);
        ProductsEntity CreateProduct(ProductsEntity item);
        ProductsEntity PutProduct(int pId, ProductsEntity item);
        ProductsEntity PatchProduct(int pId, ProductsEntity item);
        bool DeleteProduct(int pId);
    }
}