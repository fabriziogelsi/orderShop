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

        public async Task<List<Item>> InitializeDb()
        {
            List<Item> itemsMenu = new List<Item>();
            Item ristretto = new Item
            {
                Name = "Ristretto",
                Price = 0.8M,
                TaxRate = 4.5M,
                Discount = false,
                DiscountItemId = "",
                DiscountPercentage = 0
            };
            Item coffeWithMilk = new Item
            {
                Name = "Coffe with milk",
                Price = 1M,
                TaxRate = 4.5M,
                Discount = false,
                DiscountItemId = "",
                DiscountPercentage = 0
            };
            Item latte = new Item
            {
                Name = "Latte",
                Price = 1.6M,
                TaxRate = 4.5M,
                Discount = false,
                DiscountItemId = "",
                DiscountPercentage = 0
            };
            itemsMenu.Add(ristretto);
            itemsMenu.Add(coffeWithMilk);
            itemsMenu.Add(latte);

            await itemCollection.InsertMany(itemsMenu);

            Item firstCoffeWithDiscount = await itemCollection.GetItemByName("Ristretto");
            Item secondCoffeWithDiscount = await itemCollection.GetItemByName("Latte");

            itemsMenu.Clear();

            Item sandwich = new Item
            {
                Name = "Sandwich",
                Price = 2M,
                TaxRate = 3M,
                Discount = true,
                DiscountItemId = firstCoffeWithDiscount.Id,
                DiscountPercentage = 80
            };
            Item snacks = new Item
            {
                Name = "Snacks",
                Price = 0.5M,
                TaxRate = 3M,
                Discount = false,
                DiscountItemId = "",
                DiscountPercentage = 0
            };
            Item croissant = new Item
            {
                Name = "Croissant",
                Price = 1.75M,
                TaxRate = 3M,
                Discount = true,
                DiscountItemId = secondCoffeWithDiscount.Id,
                DiscountPercentage = 50
            };

            itemsMenu.Add(sandwich);
            itemsMenu.Add(snacks);
            itemsMenu.Add(croissant);

            await itemCollection.InsertMany(itemsMenu);

            Item freeSnacksWithBeverage = await itemCollection.GetItemByName("Snacks");

            itemsMenu.Clear();

            Item cokeS = new Item
            {
                Name = "Coke 500ml",
                Price = 0.5M,
                TaxRate = 1.5M,
                Discount = false,
                DiscountItemId = "",
                DiscountPercentage = 0
            };
            Item cokeL = new Item
            {
                Name = "Coke 2.5l",
                Price = 0.5M,
                TaxRate = 1.5M,
                Discount = true,
                DiscountItemId = freeSnacksWithBeverage.Id,
                DiscountPercentage = 100
            };

            itemsMenu.Add(cokeS);
            itemsMenu.Add(cokeL);

            await itemCollection.InsertMany(itemsMenu);

            return await itemCollection.GetAllItems();
        }

    }
}
