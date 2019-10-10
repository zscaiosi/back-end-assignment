using MongoDB.Driver;
using Products.API.Contracts.Requests;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Validators;
using Products.API.Exceptions;

namespace Products.API.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepo;
        
        public ProductsService(IProductsRepository productsRepo) {
            _productsRepo = productsRepo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductsEntity>> ListProductsAsync(GetRequestFilter filter){
            //Checks constraints
            if (!filter.CheckPageAndSize())
                throw new ArgumentValidatorException("Invalid values.");

            var list = await _productsRepo.FindAllAsync();
            return list.Skip(filter.Page - 1).Take(filter.Size);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> FindProductAsync(long pId){
            if (pId < 1)
                throw new ArgumentValidatorException("Empty values.");

            return await _productsRepo.FindAsync(pId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> CreateProductAsync(ProductsEntity item){
            //Checks constraints
            if (item == null)
                throw new ArgumentValidatorException("Empty values.");
            if (!item.CheckId() || !item.CheckSku())
                throw new ArgumentValidatorException("Invalid values.");
            // Finds if exists
            var exists = (await _productsRepo.FindAsync(item.Id)) != null;
            if (exists)
                throw new ArgumentValidatorException("Duplicated ID.");

            return await _productsRepo.InsertAsync(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> PutProductAsync(long pId, ProductsEntity item){
            //Checks constraints
            if (item == null || pId < 1)
                throw new ArgumentValidatorException("Empty values.");
            if (!item.CheckSku())
                throw new ArgumentValidatorException("Invalid values.");

            return await _productsRepo.UpdateAsync(pId, item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProductAsync(long pId){
            if (pId < 1)
                throw new ArgumentValidatorException("Empty values.");

            return await _productsRepo.RemoveAsync(pId);
        }
    }
}