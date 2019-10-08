
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Products.API.Interfaces;

namespace Products.API.Data.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IConfiguration _config;

        public MongoRepository(MongoClient mongoClient, IConfiguration config){
            _mongoClient = mongoClient;
            _config = config;
        }
        public MongoRepository(MongoClient mongoClient){
            _mongoClient = mongoClient;
        }        
        public IMongoDatabase exposeDatabase(){
            return _mongoClient.GetDatabase(_config.GetConnectionString("MONGO_DB"));
        }
        public IMongoDatabase exposeDatabase(string dbName){
            return _mongoClient.GetDatabase(dbName);
        }
    }
}