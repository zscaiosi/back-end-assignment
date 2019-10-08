using MongoDB.Driver;
using Products.API.Data.Entities;
using Products.API.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Products.API.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoRepository _mongoRepo;
        private IMongoDatabase _db {get;set;}

        public ProductsRepository(IMongoRepository mongoRepo) {
            _mongoRepo = mongoRepo;
            _db = _mongoRepo.exposeDatabase("test");
        }
        public IEnumerable<ProductsEntity> FindAll() =>
            _db.GetCollection<ProductsEntity>("Products").AsQueryable();
    }
}