using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Contracts.Requests;
using Products.API.Contracts.Views;
using Products.API.Data.Entities;

namespace Products.API.Interfaces
{
    public interface IPurchasesService
    {
        Task<IEnumerable<PurchasesEntity>> ListPurchases(GetRequestFilter filter);
        Task<PurchasesEntity> FindPurchase(long pId);
        Task<PurchasesEntity> CreatePurchase(PurchaseOperationView item);
        Task<PurchasesEntity> PutPurchase(long pId, PurchasesEntity item);
        Task<bool> DeletePurchase(long pId);
    }
}