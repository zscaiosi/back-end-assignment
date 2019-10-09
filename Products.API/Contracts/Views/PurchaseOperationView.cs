using Products.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Contracts.Views
{
    public class PurchaseOperationView
    {
        /// <summary>
        /// The number of bundles to buy in a purchase
        /// </summary>
        public int Quantity { get; set; } = 1;
        /// <summary>
        /// The Bundle itself
        /// </summary>
        public BundlesEntity Bundle { get; set; }
        /// <summary>
        /// Buyer's CNPJ
        /// </summary>
        public string Cnpj {get;set;}
    }
}
