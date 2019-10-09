using System.Collections.Generic;
using Products.API.Data.Entities;
using Products.API.Contracts.Requests;
using System.Threading.Tasks;

namespace Products.API.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductsEntity>> ListProductsAsync(GetRequestFilter filters);
        Task<ProductsEntity> FindProductAsync(long pId);
        Task<ProductsEntity> CreateProductAsync(ProductsEntity item);
        Task<ProductsEntity> PutProductAsync(long pId, ProductsEntity item);
        Task<bool> DeleteProductAsync(long pId);
    }
}