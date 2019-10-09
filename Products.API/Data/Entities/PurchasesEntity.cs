using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Products.API.Data.Entities
{
    public class PurchasesEntity
    {
        [BsonElement("_id")]
        [JsonProperty("_id")]
        public long Id {get;set;}
        [BsonElement("cnpj")]
        public string Cnpj { get; set; }
        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }
        [BsonElement("bundleId")]
        public long BundleId { get; set; }
        [BsonElement("expenditures")]
        public decimal Expenditures {get;set;}
        [BsonElement("deleted")]
        public bool Deleted {get;set;}
    }
}
