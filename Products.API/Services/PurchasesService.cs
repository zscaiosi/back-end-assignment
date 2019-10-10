using Products.API.Contracts.Requests;
using Products.API.Contracts.Views;
using Products.API.Data.Entities;
using Products.API.Exceptions;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PurchasesEntity>> ListPurchases(GetRequestFilter filter) =>
            (await _purchasesRepo.ListAsync(filter)).Skip(filter.Page - 1).Take(filter.Size);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<PurchasesEntity> FindPurchase(string pId) =>
            await _purchasesRepo.FindAsync(pId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<PurchasesEntity> CreatePurchase(PurchaseOperationView item){
            if (!item.CheckPurchaseView())
                throw new ArgumentValidatorException("Invalid values.");
            // Finds all products which are related to this Bundle of Products
            var bundle = await _bundleRepo.FindAsync(item.Bundle.Id);
            // Does not exist yet then creates one. (Assuming Bundles are created on demand)
            if (bundle == null)
                await _bundleRepo.CreateAsync(item.Bundle);

            var products = (await _productsRepo.FindAllAsync()).Where(pr => pr.bundleId == item.Bundle.Id);
            if (products.Count() < 1)
                throw new ArgumentValidatorException("There are no valid Products for this Bundle.");

            // Sum all product's prices
            var sum = products.Select(prd => prd.SalesPrice).Sum();

            var p = new PurchasesEntity{
                Id = $"{products.First().Sku}0{DateTime.UtcNow.Millisecond}",
                Cnpj = item.Cnpj,
                CreatedAt = DateTime.UtcNow.ToString(),
                BundleId = item.Bundle.Id,
                Expenditures = sum * item.Bundle.Quantity * item.Quantity,
                Deleted = false
            };

            return await _purchasesRepo.CreateAsync(p);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<PurchasesEntity> PutPurchase(long pId, PurchasesEntity item){
            return await _purchasesRepo.ModifyAsync(pId, item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<bool> DeletePurchase(string pId){
            if (string.IsNullOrEmpty(pId))
                throw new ArgumentValidatorException("Invalid values.");

            return await _purchasesRepo.DeleteAsync(pId);
        }
    }
}