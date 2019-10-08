using Products.API.Interfaces;
using System;
using System.Collections.Generic;

namespace Products.API.Services
{
    public class ProductsService : IProductsService
    {
        public IEnumerable<object> ListProducts(){
            throw new NotImplementedException();
        }
        public object FindProduct(int pId){
            throw new NotImplementedException();
        }
        public object CreateProduct(object item){
            throw new NotImplementedException();
        }
        public object PutProduct(int pId, object item){
            throw new NotImplementedException();
        }
        public object PatchProduct(int pId, object item){
            throw new NotImplementedException();
        }
        public bool DeleteProduct(int pId){
            throw new NotImplementedException();
        }
    }
}