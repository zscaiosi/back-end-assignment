using System.Collections.Generic;
using Products.API.Data.Entities;

namespace Products.API.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<ProductsEntity> FindAll();
    }
}