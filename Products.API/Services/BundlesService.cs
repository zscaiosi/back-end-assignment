using Products.API.Contracts.Requests;
using Products.API.Contracts.Views;
using Products.API.Data.Entities;
using Products.API.Exceptions;
using Products.API.Interfaces;
using Products.API.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Services
{
    public class BundlesService : IBundlesService
    {
        private readonly IProductsOperationsRepository<BundlesEntity> _bundleRepo;
        public BundlesService(IProductsOperationsRepository<BundlesEntity> bundleRepo)
        {
            _bundleRepo = bundleRepo;
        }
        /// <summary>
        /// Creates many Bundles at once
        /// </summary>
        /// <param name="bundles"></param>
        /// <returns></returns>
        public async Task BulkCreateBundlesAsync(List<BundlesEntity> bundles)
        {
            if (bundles.Where(bs => bs.Id < 1).Any())
                throw new ArgumentValidatorException("Invalid values.");

            await _bundleRepo.BulkCreateAsync(bundles);
        }
        /// <summary>
        /// List all Bundles
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<BundlesEntity>> ListBundlesAsync(GetRequestFilter filter)
        {
            if (!filter.CheckPageAndSize())
                throw new ArgumentValidatorException("Invalid values.");

            return (await _bundleRepo.ListAsync(filter)).ToList();
        }
    }
}
