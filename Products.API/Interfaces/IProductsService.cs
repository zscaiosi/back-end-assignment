using System.Collections.Generic;

namespace Products.API.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<object> ListProducts();
        object FindProduct(int pId);
        object CreateProduct(object item);
        object PutProduct(int pId, object item);
        object PatchProduct(int pId, object item);
        bool DeleteProduct(int pId);
    }
}