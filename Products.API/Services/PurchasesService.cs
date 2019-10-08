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
            (await _purchasesRepo.ListAsync<PurchasesEntity>(filter)).Skip(filter.Page - 1).Take(filter.Size);
        public async Task<PurchasesEntity> FindPurchase(long pId) =>
            await _purchasesRepo.FindAsync<PurchasesEntity>(pId);
        public async Task<PurchasesEntity> CreatePurchase(PurchasesEntity item){
            throw new NotImplementedException();
        }
        public async Task<PurchasesEntity> PutPurchase(long pId, PurchasesEntity item){
            throw new NotImplementedException();
        }
        public async Task<PurchasesEntity> PatchPurchase(long pId, PurchasesEntity item){
            throw new NotImplementedException();
        }
        public async Task<bool> DeletePurchase(long pId){
            throw new NotImplementedException();
        }        
    }
}