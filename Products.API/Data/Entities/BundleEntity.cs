using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BundleEntity {
    public class BundleEntity {
        [BsonId]
        [BsonElement("_id")]
        public long Id {get;set;}
        [BsonElement("totalPrice")]
        public decimal TotalPrice {get;set;}
    }
}