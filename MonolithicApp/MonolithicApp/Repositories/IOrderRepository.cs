using System.Collections.Generic;
using MonolithicApp.Domain;

namespace MonolithicApp.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders(string customerId);
        string PlaceOrder(Order order);
    }
}