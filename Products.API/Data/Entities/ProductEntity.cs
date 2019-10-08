using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Products.API.Data.Entities {
    public class ProductsEntity {
        [BsonId]
        [BsonElement("_id")]
        public object Id {get;set;}
        [BsonElement("sku")]
        public string Sku {get;set;}
        [BsonElement("description")]
        public string description {get;set;}
        [BsonElement("createdAt")]
        public string createdAt {get;set;}
        [BsonElement("bundleId")]
        public string bundleId {get;set;}
        [BsonElement("salesPrice")]
        public decimal salesPrice {get;set;}
    }
}