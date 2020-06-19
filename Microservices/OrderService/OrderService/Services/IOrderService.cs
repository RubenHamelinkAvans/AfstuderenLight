using System.Collections.Generic;
using OrderService.Domain;

namespace OrderService.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders(string customerId);
        string PlaceOrder(Order order);
    }
}