using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Contracts.Requests;

namespace Products.API.Interfaces
{
    public interface IProductsOperationsRepository<T>
    {
        Task<T> CreateAsync(T e);
        Task BulkCreateAsync(IEnumerable<T> l);
        Task<T> ModifyAsync(long id, T e);
        Task<bool> DeleteAsync(long id);
        Task<T> FindAsync(long id);
        Task<IEnumerable<T>> ListAsync(GetRequestFilter filter);
    }
}