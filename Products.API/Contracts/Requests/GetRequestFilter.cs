using System.Collections.Generic;

namespace Products.API.Contracts.Requests {
    public class GetRequestFilter {
        public int Page {get;set;}
        public int Size {get;set;}
    }
}