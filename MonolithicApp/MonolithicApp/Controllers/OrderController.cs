using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonolithicApp.Domain;
using MonolithicApp.Services;

namespace MonolithicApp.Controllers
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
            logger.LogInformation($"Getting orders for customer {customerId}");
            return orderService.GetOrders(customerId);
        }

        [HttpPost]
        public string Place(Order order)
        {
            logger.LogInformation($"Placing order {order.Item} for {order.CustomerId}");
            return orderService.PlaceOrder(order);
        }
    }
}