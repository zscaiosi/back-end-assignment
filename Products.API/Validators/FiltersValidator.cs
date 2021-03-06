﻿using Products.API.Contracts.Requests;
using Products.API.Contracts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Validators
{
    public static class FiltersValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static bool CheckPageAndSize(this GetRequestFilter f) =>
            f.Page > 0 && f.Size > 0;

        public static bool CheckPurchaseView(this PurchaseOperationView v) {
            if (v.Bundle == null)
                return false;
            if (string.IsNullOrEmpty(v.Cnpj))
                return false;
            
            return true;
        }
    }
}
