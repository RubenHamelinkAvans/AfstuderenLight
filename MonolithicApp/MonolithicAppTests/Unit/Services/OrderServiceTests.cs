using System.Collections.Generic;
using MonolithicApp.Domain;
using MonolithicApp.Repositories;
using MonolithicApp.Services;
using Moq;
using NUnit.Framework;

namespace MonolithicAppTests.Unit.Services
{
    public class OrderServiceTests
    {
        private Mock<IOrderRepository> repositoryMock;
        private Mock<ICustomerService> customerServiceMock;
        private OrderService orderService;

        [SetUp]
        public void Setup()
        {
            customerServiceMock = new Mock<ICustomerService>();
            repositoryMock = new Mock<IOrderRepository>();

            customerServiceMock.Setup(c => c.Exists("existing")).Returns(true);
            customerServiceMock.Setup(c => c.Exists("noone")).Returns(false);

            repositoryMock.Setup(c => c.PlaceOrder(It.IsAny<Order>())).Returns("test");
            repositoryMock.Setup(r => r.GetOrders("test")).Returns(new List<Order>
            {
                {new Order("testId", "test", "testItem")}
            });

            orderService = new OrderService(customerServiceMock.Object, repositoryMock.Object);
        }

        [Test]
        public void PlaceOrderExistingCustomer()
        {
            var id = orderService.PlaceOrder(new Order("existing", "testItem"));

            Assert.AreEqual("test", id);
        }

        [Test]
        public void PlaceOrderNonExistentCustomer()
        {
            var id = orderService.PlaceOrder(new Order("noone", "testItem"));

            Assert.IsTrue(string.IsNullOrEmpty(id));
        }

        [Test]
        public void GetOrders()
        {
            var orders = orderService.GetOrders("test");
            
            Assert.AreEqual(1, orders.Count);
        }
    }
}