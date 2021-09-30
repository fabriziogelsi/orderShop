using orderApi.Domain.Enums;
using orderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderApi.Repositories
{
    public interface IOrderCollection
    {
        Task<List<Order>> GetAllOrders();

        Task<List<Order>> GetOrdersByStatus(Status status);

        Task InsertOrder(Order order);

        Task UpdateOrder(Order order);
    }
}
