using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Data.Entities;

namespace Products.API.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<ProductsEntity>> FindAllAsync();
        Task<ProductsEntity> FindAsync(long pId);
        Task<ProductsEntity> InsertAsync(ProductsEntity p);
        Task<ProductsEntity> UpdateAsync(long pId, ProductsEntity p);
        Task<bool> RemoveAsync(int pId);
    }
}