using orderApi.Models;
using orderApi.Repositories;
using orderApi.Util.SystemInfo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderApi.Services
{
    public class OrderService
    {
        private readonly ItemCollection itemCollection;
        private readonly OrderCollection orderCollection;

        public OrderService(ItemCollection itemCollection, OrderCollection orderCollection)
        {
            this.itemCollection = itemCollection;
            this.orderCollection = orderCollection;
        }

        public async Task<Order> PlaceAnOrder(List<string> itemsIds, string customerName)
        {
            List<Item> itemsRequested = new List<Item>();
            Item itemRequested;
            
            foreach(string itemId in itemsIds)
            {
                itemRequested = await itemCollection.GetItemById(itemId);
                itemsRequested.Add(itemRequested);
            }

            Order order = new Order()
            {
                Items = itemsRequested,
                Price = calculateOrderPrice(itemsRequested),
                Status = Domain.Enums.Status.CONFIRMED,
                CustomerName = customerName,
                DeliveryTime = Time.GetCurrentTimeInUnixTimestampPlusTimeToWait()
            };

            await orderCollection.InsertOrder(order);

            return order;
        }

        public async Task<List<Order>> GetOrdersReady()
        {
            List<Order> ordersConfirmed = await orderCollection.GetOrdersByStatus(Domain.Enums.Status.CONFIRMED);
            
            foreach(Order order in ordersConfirmed)
            {
                if (order.DeliveryTime < Time.GetCurrentTimeInUnixTimestamp())
                {
                    order.Status = Domain.Enums.Status.READY;
                    await orderCollection.UpdateOrder(order);
                }
            }

            return ordersConfirmed.Where(o => o.Status == Domain.Enums.Status.READY).ToList();
        }

        private decimal calculateOrderPrice(List<Item> itemsRequested)
        {
            decimal orderPrice = 0;
            List<Item> itemsProvideDiscount = itemsRequested.Where(i => i.Discount == true).ToList();
            //case base
            if (!itemsProvideDiscount.Any())
            {
                orderPrice = itemsRequested.Sum(i => i.Price + (i.Price * i.TaxRate / 100));
            }
            else
            {
                List<Item> items = new List<Item>();
                items.AddRange(itemsRequested);
                Item searchedItem = null;
                foreach (Item item in itemsProvideDiscount)
                {
                    orderPrice += (item.Price + (item.Price * item.TaxRate / 100));

                    searchedItem = items.FirstOrDefault(i => i.Id == item.DiscountItemId);
                    
                    if (searchedItem != null)
                    {
                        orderPrice += ((searchedItem.Price + (searchedItem.Price * searchedItem.TaxRate / 100)) * ((100 - item.DiscountPercentage) / 100));
                        items.Remove(searchedItem);
                        searchedItem = null;
                    }

                    items.Remove(item);
                }
                if (items.Any())
                {
                    orderPrice += items.Sum(i => i.Price + (i.Price * i.TaxRate / 100));
                }
            }

            return orderPrice;
        }
    }
}
