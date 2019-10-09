using Products.API.Contracts.Requests;
using Products.API.Contracts.Views;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using Products.API.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Services
{
    public class PurchasesService : IPurchasesService
    {
        private readonly IProductsOperationsRepository<PurchasesEntity> _purchasesRepo;
        private readonly IProductsRepository _productsRepo;
        private readonly IProductsOperationsRepository<BundlesEntity> _bundleRepo;
        public PurchasesService(IProductsOperationsRepository<PurchasesEntity> purchasesRepo,
            IProductsRepository productsRepo,
            IProductsOperationsRepository<BundlesEntity> bundleRepo) {
            _purchasesRepo = purchasesRepo;
            _productsRepo = productsRepo;
            _bundleRepo = bundleRepo;
        }
        public async Task<IEnumerable<PurchasesEntity>> ListPurchases(GetRequestFilter filter) =>
            (await _purchasesRepo.ListAsync(filter)).Skip(filter.Page - 1).Take(filter.Size);
        public async Task<PurchasesEntity> FindPurchase(long pId) =>
            await _purchasesRepo.FindAsync(pId);
        public async Task<PurchasesEntity> CreatePurchase(PurchaseOperationView item){
            if (!item.CheckPurchaseView())
                throw new ArgumentException();
            // First creates all entitites
            var products = (await _productsRepo.FindAllAsync()).Where(pr => pr.bundleId == item.Bundle.Id);

            var sum = products.Select(prd => prd.salesPrice).Sum();
            var p = new PurchasesEntity{
                Id = 1,
                Cnpj = item.Cnpj,
                CreatedAt = DateTime.UtcNow.ToString(),
                BundleId = item.Bundle.Id,
                Expenditures = sum * item.Bundle.Quantity,
                Deleted = false
            };

            var b = await _bundleRepo.CreateAsync(item.Bundle);
            
            return await _purchasesRepo.CreateAsync(p);
        }
        public async Task<PurchasesEntity> PutPurchase(long pId, PurchasesEntity item){
            return await _purchasesRepo.ModifyAsync(pId, item);
        }
        public async Task<bool> DeletePurchase(long pId){
            return await _purchasesRepo.DeleteAsync(pId);
        }        
    }
}