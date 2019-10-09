using Products.API.Contracts.Requests;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Services
{
    public class PurchasesService : IPurchasesService
    {
        private readonly IProductsOperationsRepository<PurchasesEntity> _purchasesRepo;
        public PurchasesService(IProductsOperationsRepository<PurchasesEntity> purchasesRepo) {
            _purchasesRepo = purchasesRepo;
        }
        public async Task<IEnumerable<PurchasesEntity>> ListPurchases(GetRequestFilter filter) =>
            (await _purchasesRepo.ListAsync(filter)).Skip(filter.Page - 1).Take(filter.Size);
        public async Task<PurchasesEntity> FindPurchase(long pId) =>
            await _purchasesRepo.FindAsync(pId);
        public async Task<PurchasesEntity> CreatePurchase(PurchasesEntity item){
            return await _purchasesRepo.CreateAsync(item);
        }
        public async Task<PurchasesEntity> PutPurchase(long pId, PurchasesEntity item){
            return await _purchasesRepo.ModifyAsync(pId, item);
        }
        public async Task<bool> DeletePurchase(long pId){
            return await _purchasesRepo.DeleteAsync(pId);
        }        
    }
}