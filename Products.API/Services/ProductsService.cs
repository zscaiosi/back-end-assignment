using MongoDB.Driver;
using Products.API.Contracts.Requests;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Products.API.Validators;

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
                throw new ArgumentException();

            var list = await _productsRepo.FindAllAsync();
            return list.Skip(filter.Page - 1).Take(filter.Size);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> FindProductAsync(int pId){
            if (pId < 1)
                throw new ArgumentException();

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
                throw new ArgumentException();
            if (item.CheckId() == false || item.CheckSku() == false)
                throw new ArgumentException();

            return await _productsRepo.InsertAsync(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> PutProductAsync(int pId, ProductsEntity item){
            //Checks constraints
            if (item == null || pId < 1)
                throw new ArgumentException();
            if (!item.CheckId() || !item.CheckSku())
                throw new ArgumentException();

            return await _productsRepo.UpdateAsync(pId, item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProductAsync(int pId){
            if (pId < 1)
                throw new ArgumentException();

            return await _productsRepo.RemoveAsync(pId);
        }
    }
}