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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;

namespace Products.API.Tests
{
    public class ProductsApiTDD
    {
        private IConfigurationBuilder cb;
        private IConfiguration configuration;
        private IMongoRepository mongoRepo;
        private IProductsRepository productRepo;
        private IProductsService productsService;
        private ProductsEntity product;
        public ProductsApiTDD() {
            IHostingEnvironment hosting = new HostingEnvironment();
            cb = new ConfigurationBuilder();
            cb.AddJsonFile(hosting.ContentRootPath + "appsettings.json");
            configuration = cb.Build();
            mongoRepo = new MongoRepository(configuration, new MongoClient("mongodb://localhost:27017/test"));
            productRepo = new ProductsRepository(mongoRepo);
            productsService = new ProductsService(productRepo);
            product = new ProductsEntity
            {
                Id = 10,
                description = "TDD",
                bundleId = 1,
                createdAt = DateTime.UtcNow.ToString(),
                salesPrice = (decimal)10.00,
                Sku = "t10"
            };
        }
        [Fact]
        public void CollectionIsFilled()
        {
            var client = mongoRepo.exposeDatabase("test");
            var col = client.GetCollection<ProductsEntity>("Products");

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
        [Fact]
        public async Task CreatesAProduct()
        {
            var created = await productsService.CreateProductAsync(product);
            var found = await productsService.FindProductAsync(created.Id);

            Assert.NotNull(found);
        }
    }
}
