using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Products.API.Data.Entities
{
    public class PurchasesEntity
    {
        [BsonId]
        [BsonElement("_id")]
        public long Id { get; set; }
        [BsonElement("cnpj")]
        public string Cnpj { get; set; }
        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }
        [BsonElement("bundleId")]
        public long bundleId { get; set; }
    }
}
