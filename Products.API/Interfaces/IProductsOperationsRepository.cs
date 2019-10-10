using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Contracts.Requests;

namespace Products.API.Interfaces
{
    public interface IProductsOperationsRepository<T>
    {
        Task<T> CreateAsync(T e);
        Task BulkCreateAsync(IEnumerable<T> l);
        Task<T> ModifyAsync(object id, T e);
        Task<bool> DeleteAsync(object id);
        Task<T> FindAsync(object id);
        Task<IEnumerable<T>> ListAsync(GetRequestFilter filter);
    }
}