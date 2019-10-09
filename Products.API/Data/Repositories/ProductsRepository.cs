using MongoDB.Driver;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Products.API.Contracts.Views;

namespace Products.API.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoRepository _mongoRepo;
        private IMongoDatabase _db { get; set; }
        private IMongoCollection<ProductsEntity> _collection { get; set; }
        private const string COLLECTION_NAME = "Products";
        private FilterDefinitionBuilder<ProductsEntity> filter;
        private UpdateDefinitionBuilder<ProductsEntity> updater;

        public ProductsRepository(IMongoRepository mongoRepo) {
            _mongoRepo = mongoRepo;
            _db = _mongoRepo.exposeDatabase("test");
            _collection = _db.GetCollection<ProductsEntity>(COLLECTION_NAME);
            filter = Builders<ProductsEntity>.Filter;
            updater = Builders<ProductsEntity>.Update;
        }
        /// <summary>
        /// Lists all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductsEntity>> FindAllAsync() =>
            await _db.GetCollection<ProductsEntity>(COLLECTION_NAME).AsQueryable().ToListAsync();
        /// <summary>
        /// Finds a document
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> FindAsync(long pId) =>
            (await _db.GetCollection<ProductsEntity>(COLLECTION_NAME).FindAsync(e => e.Id == pId)).FirstOrDefault();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> InsertAsync(ProductsEntity p)
        {
            await _collection.InsertOneAsync(p);
            return p;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<ProductsEntity> UpdateAsync(long pId, ProductsEntity p)
        {
            await _collection.UpdateOneAsync(filter.Eq("_id", pId), updater.Set("sku", p.Sku).Set("salesPrice", p.SalesPrice).Set("description", p.description).Set("bundleId", p.bundleId));
            return p;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(long pId) =>
            (await _collection.DeleteOneAsync(filter.Eq("_id", pId))).DeletedCount > 0;
    }
}