using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Contracts.Requests;

namespace Products.API.Interfaces
{
    public interface IProductsOperationsRepository<T>
    {
        Task<T> CreateAsync<T>(T e);
        Task<T> ModifyAsync<T>(long id, T e);
        Task<bool> DeleteAsync<T>(long id);
        Task<T> FindAsync<T>(long id);
        Task<IEnumerable<T>> ListAsync<T>(GetRequestFilter filter);
    }
}