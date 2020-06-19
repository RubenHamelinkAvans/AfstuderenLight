﻿using System.Collections.Generic;
using OrderService.Domain;
using OrderService.Repositories;

namespace OrderService.Services
{
    public class OrderService : IOrderService
    {
        private ICustomerService customerService;
        private IOrderRepository orderRepository;

        public OrderService(ICustomerService customerService, IOrderRepository orderRepository)
        {
            this.customerService = customerService;
            this.orderRepository = orderRepository;
        }

        public List<Order> GetOrders(string customerId)
        {
            return orderRepository.GetOrders(customerId);
        }

        public string PlaceOrder(Order order)
        {
            if (!customerService.Exists(order.CustomerId))
                return null;
            return orderRepository.PlaceOrder(order);
        }
    }
}