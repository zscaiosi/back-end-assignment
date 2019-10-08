using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Products.API.Data.Entities {
    public class ProductsEntity {
        [BsonId]
        [BsonElement("_id")]
        [JsonProperty("_id")]
        public long Id {get;set;}
        [BsonElement("sku")]
        public string Sku {get;set;}
        [BsonElement("description")]
        public string description {get;set;}
        [BsonElement("createdAt")]
        public string createdAt {get;set;}
        [BsonElement("bundleId")]
        public long bundleId {get;set;}
        [BsonElement("salesPrice")]
        public decimal salesPrice {get;set;}
    }
}