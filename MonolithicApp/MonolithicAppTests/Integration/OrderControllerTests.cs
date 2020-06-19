using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MonolithicApp;
using MonolithicApp.Domain;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MonolithicAppTests.Integration
{
    public class OrderControllerTests 
    {
        private WebApplicationFactory<Startup> factory;
        
        [SetUp]
        public void Setup()
        {
            factory = new WebApplicationFactory<Startup>();
        }

        [Test]
        public async Task PlaceOrderWithInvalidCustomer()
        {
            using var client = factory.CreateClient();
            
            var response = await client.PostAsJsonAsync("/Order", new Order() {CustomerId = "noone", Item = "testItem"});

            var orderId = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(string.IsNullOrEmpty(orderId));
        }

        [Test]
        public async Task CreateCustomerAndPlaceOrderSuccess()
        {
            using var client = factory.CreateClient();

            var response = await client.PostAsJsonAsync("/Customer", new Customer("testName"));
            var customerId = await response.Content.ReadAsStringAsync();
            
            response = await client.PostAsJsonAsync("/Order", new Order() {CustomerId = customerId, Item = "testItem"});

            var orderId = await response.Content.ReadAsStringAsync();

            response = await client.GetAsync($"/Order?customerId={customerId}");

            string orderListString = await response.Content.ReadAsStringAsync();

            var orderList = JsonConvert.DeserializeObject<IEnumerable<Order>>(orderListString).ToList();
                
            Assert.AreEqual(1, orderList.Count);
            Assert.AreEqual(orderId, orderList[0].Id);
            Assert.AreEqual("testItem", orderList[0].Item);
            Assert.AreEqual(customerId, orderList[0].CustomerId);
        }
    }
}