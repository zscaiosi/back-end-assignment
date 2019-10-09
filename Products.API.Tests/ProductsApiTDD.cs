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
using Products.API.Exceptions;

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
            IHostingEnvironment hosting = new HostingEnvironment();
            cb = new ConfigurationBuilder();
            cb.AddJsonFile(hosting.ContentRootPath + "appsettings.json");
            configuration = cb.Build();
            mongoRepo = new MongoRepository(configuration, new MongoClient("mongodb://localhost:27017/test"));
            productRepo = new ProductsRepository(mongoRepo);
            productsService = new ProductsService(productRepo);

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
        [Theory]
        [InlineData(null)]
        public async Task ThrowsExceptionIfNull(ProductsEntity product)
        {
            try
            {
                var created = await productsService.CreateProductAsync(product);
                var found = await productsService.FindProductAsync(created.Id);
            }
            catch (Exception e)
            {
                Assert.IsType(new ArgumentValidatorException("").GetType(), e);
            }
        }
    }
}
