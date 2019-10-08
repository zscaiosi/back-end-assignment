using System;
using Xunit;
using Products.API.Services;
using Products.API.Interfaces;
using Products.API.Data.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using Products.API.Data.Entities;

namespace Products.API.Tests
{
    public class ProductsApiTDD
    {
        IMongoRepository mongoRepo = new MongoRepository(new MongoClient("mongodb://localhost:27017/test"));
        [Fact]
        public void CollectionIsFilled()
        {
            var client = mongoRepo.exposeDatabase("test");
            var col = client.GetCollection<ProductsEntity>("Product");
            Assert.True(col.AsQueryable().FirstOrDefault() != null);
        }
    }
}
