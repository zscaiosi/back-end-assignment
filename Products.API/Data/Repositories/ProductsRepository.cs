using MongoDB.Driver;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Products.API.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoRepository _mongoRepo;
        private IMongoDatabase _db { get; set; }
        private const string COLLECTION_NAME = "Products";
        private FilterDefinitionBuilder<ProductsEntity> filter;
        private UpdateDefinitionBuilder<ProductsEntity> updater;

        public ProductsRepository(IMongoRepository mongoRepo) {
            _mongoRepo = mongoRepo;
            _db = _mongoRepo.exposeDatabase("test");
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
        public async Task<ProductsEntity> InsertAsync(ProductsEntity p)
        {
            //await _db.GetCollection<ProductsEntity>(COLLECTION_NAME).InsertOneAsync(p);
            throw new NotImplementedException();
        }
        public async Task<ProductsEntity> UpdateAsync(long pId, ProductsEntity p)
        {
            //return await _db.GetCollection<ProductsEntity>(COLLECTION_NAME).FindOneAndUpdateAsync(filter.Eq("_id", pId));
            throw new NotImplementedException();
        }
        public async Task<ProductsEntity> ModifyAsync(int pId, ProductsEntity p)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> RemoveAsync(int pId)
        {
            throw new NotImplementedException();
        }
    }
}