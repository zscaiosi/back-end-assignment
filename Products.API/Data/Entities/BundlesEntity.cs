using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Products.API.Data.Entities
{
    public class BundlesEntity
    {
        [BsonElement("_id")]
        public long Id { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
