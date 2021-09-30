using orderApi.Models;
using orderApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace orderApi.Services
{
    public class ItemService
    {
        private readonly ItemCollection itemCollection;

        public ItemService(ItemCollection itemCollection)
        {
            this.itemCollection = itemCollection;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await itemCollection.GetAllItems();
        }

        public async Task<Item> GetItemById(string id)
        {
            return await itemCollection.GetItemById(id);
        }

        public async Task InsertItem(Item item)
        {
            await itemCollection.InsertItem(item);
        }

        public async Task InsertMany(List<Item> items)
        {
            await itemCollection.InsertMany(items);
        }

        public async Task UpdateItem(Item item)
        {
            await itemCollection.UpdateItem(item);
        }

        public async Task DeleteItem(string id)
        {
            await itemCollection.DeleteItem(id);
        }

    }
}
