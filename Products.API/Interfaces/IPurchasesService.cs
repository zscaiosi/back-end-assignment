using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Contracts.Requests;
using Products.API.Data.Entities;

namespace Products.API.Interfaces
{
    public interface IPurchasesService
    {
        Task<IEnumerable<PurchasesEntity>> ListPurchases(GetRequestFilter filter);
        Task<PurchasesEntity> FindPurchase(int pId);
        Task<PurchasesEntity> CreatePurchase(PurchasesEntity item);
        Task<PurchasesEntity> PutPurchase(int pId, PurchasesEntity item);
        Task<PurchasesEntity> PatchPurchase(int pId, PurchasesEntity item);
        Task<bool> DeletePurchase(int pId);
    }
}