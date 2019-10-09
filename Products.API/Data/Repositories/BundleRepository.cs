using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Products.API.Contracts.Requests;
using Products.API.Interfaces;

namespace Products.API.Data.Repositories
{
    public class BundleRepository<BundlesEntity> : IProductsOperationsRepository<BundlesEntity>
    {
        private readonly IMongoRepository _mongoRepo;
        private IMongoDatabase _db { get; set; }
        private IMongoCollection<BundlesEntity> _collection { get; set; }
        private const string COLLECTION_NAME = "Bundles";
        private FilterDefinitionBuilder<BundlesEntity> filter;
        private UpdateDefinitionBuilder<BundlesEntity> updater;        
        public BundleRepository(IMongoRepository mongoRepo) {
            _mongoRepo = mongoRepo;
            _db = _mongoRepo.exposeDatabase("test");
            _collection = _db.GetCollection<BundlesEntity>(COLLECTION_NAME);
            filter = Builders<BundlesEntity>.Filter;
            updater = Builders<BundlesEntity>.Update;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task<BundlesEntity> CreateAsync(BundlesEntity e){
            await _collection.InsertOneAsync(e);
            return e;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bundles"></param>
        /// <returns></returns>
        public async Task BulkCreateAsync(IEnumerable<BundlesEntity> bundles) =>
            await _collection.InsertManyAsync(bundles);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task<BundlesEntity> ModifyAsync(long id, BundlesEntity e){
            await _collection.ReplaceOneAsync(filter.Eq("_id", id), e);
            return e;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(long id) =>
            (await _collection.DeleteOneAsync(filter.Eq("_id", id))).DeletedCount > 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public async Task<BundlesEntity> FindAsync(long pId) =>
            (await _db.GetCollection<BundlesEntity>(COLLECTION_NAME).FindAsync(filter.Eq("_id", pId))).FirstOrDefault();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>

        public async Task<IEnumerable<BundlesEntity>> ListAsync(GetRequestFilter filter) =>
            await _db.GetCollection<BundlesEntity>(COLLECTION_NAME).AsQueryable().ToListAsync();
    }
}