using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Products.API.Contracts.Requests;
using Products.API.Interfaces;

namespace Products.API.Data.Repositories
{
    public class PurchasesRepository<PurchasesEntity> : IProductsOperationsRepository<PurchasesEntity>
    {
        private readonly IMongoRepository _mongoRepo;
        private IMongoDatabase _db { get; set; }
        private IMongoCollection<PurchasesEntity> _collection { get; set; }
        private const string COLLECTION_NAME = "Purchases";
        private FilterDefinitionBuilder<PurchasesEntity> filter;
        private UpdateDefinitionBuilder<PurchasesEntity> updater;        
        public PurchasesRepository(IMongoRepository mongoRepo) {
            _mongoRepo = mongoRepo;
            _db = _mongoRepo.exposeDatabase("test");
            _collection = _db.GetCollection<PurchasesEntity>(COLLECTION_NAME);
            filter = Builders<PurchasesEntity>.Filter;
            updater = Builders<PurchasesEntity>.Update;
        }
        public async Task<PurchasesEntity> CreateAsync(PurchasesEntity e){
            await _collection.InsertOneAsync(e);
            return e;
        }
        public async Task<PurchasesEntity> ModifyAsync(long id, PurchasesEntity e){
            await _collection.ReplaceOneAsync(filter.Eq("_id", id), e);
            return e;
        }
        public async Task<bool> DeleteAsync(long id) =>
            (await _collection.DeleteOneAsync(filter.Eq("_id", id))).DeletedCount > 0;
        public async Task<PurchasesEntity> FindAsync(long id) =>
            (await _db.GetCollection<PurchasesEntity>(COLLECTION_NAME).FindAsync(e => e.Id == pId)).FirstOrDefault();

        public async Task<IEnumerable<PurchasesEntity>> ListAsync(GetRequestFilter filter) =>
            await _db.GetCollection<PurchasesEntity>(COLLECTION_NAME).AsQueryable().ToListAsync();
    }
}