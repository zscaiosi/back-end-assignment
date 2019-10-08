using Products.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Validators
{
    public static class ProductsValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        public static bool CheckId(this ProductsEntity pe) =>
            pe.Id > 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        public static bool CheckSku(this ProductsEntity pe) =>
            !string.IsNullOrEmpty(pe.Sku);
    }
}
