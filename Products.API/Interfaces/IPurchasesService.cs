using System.Collections.Generic;

namespace Products.API.Interfaces
{
    public interface IPurchasesService
    {
        IEnumerable<object> ListPurchases();
        object FindPurchase(int pId);
        object CreatePurchase(object item);
        object PutPurchase(int pId, object item);
        object PatchPurchase(int pId, object item);
        bool DeletePurchase(int pId);         
    }
}