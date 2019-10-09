using System;
using Xunit;
using Products.API.Services;
using Products.API.Interfaces;
using Products.API.Data.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using Products.API.Data.Entities;
using System.Threading.Tasks;
using Products.API.Contracts.Requests;
using System.Linq;

namespace Products.API.Tests
{
    public class ProductsApiTDD
    {
        private IConfigurationBuilder cb;
        private IConfiguration configuration;
        private IMongoRepository mongoRepo;
        private IProductsRepository productRepo;
        private IProductsService productsService;
        public ProductsApiTDD() {
            cb = new ConfigurationBuilder();
            cb.AddJsonFile("appsettings.json");
            configuration = cb.Build();
            mongoRepo = new MongoRepository(configuration, new MongoClient("mongodb://localhost:27017/test"));
            productRepo = new ProductsRepository(mongoRepo);
            productsService = new ProductsService(productRepo);
        }
        [Fact]
        public void CollectionIsFilled()
        {
            var client = mongoRepo.exposeDatabase("test");
            var col = client.GetCollection<ProductsEntity>("Product");
            Assert.True(col.AsQueryable().FirstOrDefault() != null);
        }
        [Fact]
        public async Task ListProductsGreaterThanZero()
        {
            var list = await productsService.ListProductsAsync(new GetRequestFilter {
                Page = 1,
                Size = 3
            });

            Assert.True(list.Count() > 0, "List contains elements");
        }
    }
}
