using MongoDB.Bson;
using MongoDB.Driver;
using orderApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace orderApi.Repositories
{
    public class ItemCollection : IItemCollection
    {
        internal DbRepository _repository = new DbRepository();
        private IMongoCollection<Item> Collection;

        public ItemCollection()
        {
            Collection = _repository.db.GetCollection<Item>("Items");
        }

        public async Task DeleteItem(string id)
        {
            var filter = Builders<Item>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Item> GetItemById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } })
                        .Result.FirstAsync();
        }

        public async Task<Item> GetItemByName(string name)
        {
            return await Collection.FindAsync(new BsonDocument { { "Name", name } })
                        .Result.FirstAsync();
        }

        public async Task InsertItem(Item item)
        {
            await Collection.InsertOneAsync(item);
        }

        public async Task InsertMany(List<Item> items)
        {
            await Collection.InsertManyAsync(items);
        }

        public async Task UpdateItem(Item item)
        {
            var filter = Builders<Item>.Filter.Eq(s => s.Id, item.Id);
            await Collection.ReplaceOneAsync(filter, item);
        }
    }
}
