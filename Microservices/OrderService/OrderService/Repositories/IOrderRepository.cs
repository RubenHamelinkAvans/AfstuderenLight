using System.Collections.Generic;
using OrderService.Domain;

namespace OrderService.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders(string customerId);
        string PlaceOrder(Order order);
    }
}