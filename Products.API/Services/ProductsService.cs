using MongoDB.Driver;
using Products.API.Contracts.Requests;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Products.API.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepo;
        
        public ProductsService(IProductsRepository productsRepo) {
            _productsRepo = productsRepo;
        }
        public IEnumerable<ProductsEntity> ListProducts(GetRequestFilter filter){
            var list = _productsRepo.FindAll();
            return list.Skip(filter.Page - 1).Take(filter.Size);
        }
        public ProductsEntity FindProduct(int pId){
            throw new NotImplementedException();
        }
        public ProductsEntity CreateProduct(ProductsEntity item){
            throw new NotImplementedException();
        }
        public ProductsEntity PutProduct(int pId, ProductsEntity item){
            throw new NotImplementedException();
        }
        public ProductsEntity PatchProduct(int pId, ProductsEntity item){
            throw new NotImplementedException();
        }
        public bool DeleteProduct(int pId){
            throw new NotImplementedException();
        }
    }
}