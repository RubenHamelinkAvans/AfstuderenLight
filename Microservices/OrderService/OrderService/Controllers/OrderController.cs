using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderService.Domain;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private ILogger<OrderController> logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        [HttpGet]
        public List<Order> Get(string customerId)
        {
            return orderService.GetOrders(customerId);
        }

        [HttpPost]
        public string Place(Order order)
        {
            logger.LogInformation($"Placing order {order.Item}");
            return orderService.PlaceOrder(order);
        }
    }
}