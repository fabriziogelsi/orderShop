using orderApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace orderApi.Repositories
{
    public interface IItemCollection
    {
        Task<List<Item>> GetAllItems();

        Task<Item> GetItemById(string id);

        Task<Item> GetItemByName(string name);

        Task InsertItem(Item item);

        Task InsertMany(List<Item> items);

        Task UpdateItem(Item item);

        Task DeleteItem(string id);
    }
}
