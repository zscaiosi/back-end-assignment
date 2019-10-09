using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Products.API.Contracts.Requests;
using Products.API.Interfaces;

namespace Products.API.Data.Repositories
{
    public class BundleRepository<BundleEntity> : IProductsOperationsRepository<BundleEntity>
    {
        private readonly IMongoRepository _mongoRepo;
        private IMongoDatabase _db { get; set; }
        private IMongoCollection<BundleEntity> _collection { get; set; }
        private const string COLLECTION_NAME = "Bundles";
        private FilterDefinitionBuilder<BundleEntity> filter;
        private UpdateDefinitionBuilder<BundleEntity> updater;        
        public BundleRepository(IMongoRepository mongoRepo) {
            _mongoRepo = mongoRepo;
            _db = _mongoRepo.exposeDatabase("test");
            _collection = _db.GetCollection<BundleEntity>(COLLECTION_NAME);
            filter = Builders<BundleEntity>.Filter;
            updater = Builders<BundleEntity>.Update;
        }
        public async Task<BundleEntity> CreateAsync(BundleEntity e){
            await _collection.InsertOneAsync(e);
            return e;
        }
        public async Task<BundleEntity> ModifyAsync(long id, BundleEntity e){
            await _collection.ReplaceOneAsync(filter.Eq("_id", id), e);
            return e;
        }
        public async Task<bool> DeleteAsync(long id) =>
            (await _collection.DeleteOneAsync(filter.Eq("_id", id))).DeletedCount > 0;
        public async Task<BundleEntity> FindAsync(long pId) =>
            (await _db.GetCollection<BundleEntity>(COLLECTION_NAME).FindAsync(filter.Eq("_id", pId))).FirstOrDefault();

        public async Task<IEnumerable<BundleEntity>> ListAsync(GetRequestFilter filter) =>
            await _db.GetCollection<BundleEntity>(COLLECTION_NAME).AsQueryable().ToListAsync();
    }
}