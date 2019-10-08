
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Products.API.Interfaces;

namespace Products.API.Data.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IConfiguration _config;

        public MongoRepository(IConfiguration config){
            _config = config;
            _mongoClient = new MongoClient(_config.GetConnectionString("MONGO_CONN_STR"));
        }
        public MongoRepository(IConfiguration config, MongoClient mongoClient){
            _config = config;
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