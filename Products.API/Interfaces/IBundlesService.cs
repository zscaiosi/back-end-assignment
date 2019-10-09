using Products.API.Contracts.Requests;
using Products.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Interfaces
{
    public interface IBundlesService
    {
        /// <summary>
        /// Creates many Bundles at once
        /// </summary>
        /// <param name="bundles"></param>
        /// <returns></returns>
        Task BulkCreateBundlesAsync(List<BundlesEntity> bundles);
        /// <summary>
        /// List all Bundles
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<BundlesEntity>> ListBundlesAsync(GetRequestFilter filter);
    }
}
