using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public List<Order> Get(string customerId)
        {
            return orderService.GetOrders(customerId);
        }

        [HttpPost]
        public string Place(Order order)
        {
            return orderService.PlaceOrder(order);
        }
    }
}