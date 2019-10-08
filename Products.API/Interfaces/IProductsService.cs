using System.Collections.Generic;
using Products.API.Data.Entities;
using Products.API.Contracts.Requests;
using System.Threading.Tasks;

namespace Products.API.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductsEntity>> ListProductsAsync(GetRequestFilter filters);
        Task<ProductsEntity> FindProductAsync(int pId);
        Task<ProductsEntity> CreateProductAsync(ProductsEntity item);
        Task<ProductsEntity> PutProductAsync(int pId, ProductsEntity item);
        Task<ProductsEntity> PatchProductAsync(int pId, ProductsEntity item);
        Task<bool> DeleteProductAsync(int pId);
    }
}