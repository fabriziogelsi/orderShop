using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using orderApi.Domain.Enums;
using System.Collections.Generic;

namespace orderApi.Models
{
    public class Order
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<Item> Items { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public string CustomerName { get; set; }

        public long DeliveryTime { get; set; }
    }
}
