using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Products.API.Interfaces {
    public interface IMongoRepository {
        IMongoDatabase exposeDatabase();
        IMongoDatabase exposeDatabase(string dbName);
    }
}