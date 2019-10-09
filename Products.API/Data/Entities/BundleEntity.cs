using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Products.API.Data.Entities {
    public class BundleEntity {
        [BsonId]
        [BsonElement("_id")]
        public long Id {get;set;}
        [BsonElement("totalPrice")]
        public decimal TotalPrice {get;set;}
    }
}