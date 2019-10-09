using Products.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Contracts.Views
{
    public class PurchaseOperationView
    {
        public int Quantity { get; set; }
        public BundlesEntity Bundle { get; set; }
        public string Cnpj {get;set;}
    }
}
