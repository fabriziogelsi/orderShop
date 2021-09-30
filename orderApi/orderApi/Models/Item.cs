using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace orderApi.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal TaxRate { get; set; }

        public bool Discount { get; set; }

        public string DiscountItemId { get; set; }

        public decimal DiscountPercentage { get; set; }
    }
}
