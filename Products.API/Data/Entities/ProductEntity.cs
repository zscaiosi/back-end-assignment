using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Products.API.Data.Entities {
    public class ProductEntity {
        [BsonId]
        [BsonElement("_id")]
        public string Id {get;set;}
        [BsonElement("sku")]
        public string Sku {get;set;}
        [BsonElement("description")]
        public string description {get;set;}
        [BsonElement("createdAt")]
        public string createdAt {get;set;}
        [BsonElement("bundleId")]
        public string bundleId {get;set;}
        [BsonElement("productId")]
        public string productId {get;set;}
        [BsonElement("salesPrice")]
        public string salesPrice {get;set;}
    }
}