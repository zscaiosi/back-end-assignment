using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Data.Repositories
{
    public interface IPurchasesRepository
    {
        Task<IEnumerable<TEntity>> FindAllAsync<TEntity>();
        Task<TEntity> FindAsync<TEntity>(long pId);
        Task<TEntity> InsertAsync<TEntity>(TEntity p);
        Task<TEntity> UpdateAsync<TEntity>(long pId, TEntity p);
        Task<TEntity> ModifyAsync<TEntity>(int pId, TEntity p);
        Task<bool> RemoveAsync<TEntity>(int pId);
    }
}
