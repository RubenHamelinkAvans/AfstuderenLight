using System;
using System.Collections.Generic;
using System.Linq;
using MonolithicApp.Domain;

namespace MonolithicApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders;

        public OrderRepository()
        {
            orders = new List<Order>
            {
                {new Order("0", "0", "Fiets")},
                {new Order("1", "0", "Auto")},
                {new Order("2", "2", "Basketbal")},
            };
        }
        
        public List<Order> GetOrders(string customerId)
        {
            return orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public string PlaceOrder(Order order)
        {
            order.Id = Guid.NewGuid().ToString();
            orders.Add(order);
            return order.Id;
        }
    }
}