using MongoDB.Bson;
using MongoDB.Driver;
using orderApi.Domain.Enums;
using orderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderApi.Repositories
{
    public class OrderCollection : IOrderCollection
    {
        internal DbRepository _repository = new DbRepository();
        private IMongoCollection<Order> Collection;

        public OrderCollection()
        {
            Collection = _repository.db.GetCollection<Order>("Orders");
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByStatus(Status status)
        {
            return await Collection.FindAsync(new BsonDocument { { "Status", status } })
                .Result.ToListAsync();
        }

        public async Task InsertOrder(Order order)
        {
            await Collection.InsertOneAsync(order);
        }

        public async Task UpdateOrder(Order order)
        {
            var filter = Builders<Order>.Filter.Eq(s => s.Id, order.Id);
            await Collection.ReplaceOneAsync(filter, order);
        }
    }
}
