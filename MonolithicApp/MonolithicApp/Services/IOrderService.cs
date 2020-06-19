using System.Collections.Generic;
using MonolithicApp.Domain;

namespace MonolithicApp.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders(string customerId);
        string PlaceOrder(Order order);
    }
}