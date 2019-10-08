using Products.API.Interfaces;
using System;
using System.Collections.Generic;

namespace Products.API.Services
{
    public class PurchasesService : IPurchasesService
    {
        public IEnumerable<object> ListPurchases(){
            throw new NotImplementedException();
        }
        public object FindPurchase(int pId){
            throw new NotImplementedException();
        }
        public object CreatePurchase(object item){
            throw new NotImplementedException();
        }
        public object PutPurchase(int pId, object item){
            throw new NotImplementedException();
        }
        public object PatchPurchase(int pId, object item){
            throw new NotImplementedException();
        }
        public bool DeletePurchase(int pId){
            throw new NotImplementedException();
        }        
    }
}