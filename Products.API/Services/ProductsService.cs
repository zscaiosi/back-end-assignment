using MongoDB.Driver;
using Products.API.Contracts.Requests;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.API.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepo;
        
        public ProductsService(IProductsRepository productsRepo) {
            _productsRepo = productsRepo;
        }
        public async Task<IEnumerable<ProductsEntity>> ListProductsAsync(GetRequestFilter filter){
            var list = await _productsRepo.FindAllAsync();
            return list.Skip(filter.Page - 1).Take(filter.Size);
        }
        public Task<ProductsEntity> FindProductAsync(int pId){
            throw new NotImplementedException();
        }
        public Task<ProductsEntity> CreateProductAsync(ProductsEntity item){
            throw new NotImplementedException();
        }
        public Task<ProductsEntity> PutProductAsync(int pId, ProductsEntity item){
            throw new NotImplementedException();
        }
        public Task<ProductsEntity> PatchProductAsync(int pId, ProductsEntity item){
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteProductAsync(int pId){
            throw new NotImplementedException();
        }
    }
}