using MonolithicApp.Domain;
using MonolithicApp.Repositories;
using NUnit.Framework;

namespace MonolithicAppTests.Unit.Repositories
{
    public class OrderRepositoryTests
    {
        private OrderRepository orderRepository;
        
        [SetUp]
        public void Setup()
        {
            orderRepository = new OrderRepository();
            orderRepository.PlaceOrder(new Order("testCustomer", "UnitTest"));
            orderRepository.PlaceOrder(new Order("testCustomer", "UnitTest2"));
        }

        [Test]
        public void PlaceOrder()
        {
            string id = orderRepository.PlaceOrder(new Order("0", "TestItem"));
            Assert.IsFalse(string.IsNullOrEmpty(id));
        }
        [Test]
        public void GetOrdersSuccess()
        {
            var orders = orderRepository.GetOrders("testCustomer");
            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual("UnitTest", orders[0].Item);
            Assert.AreEqual("UnitTest2", orders[1].Item);
        }
        [Test]
        public void GetOrdersNonExistent()
        {
            var orders = orderRepository.GetOrders("noone");
            Assert.AreEqual(0, orders.Count);
        }
        
    }
}