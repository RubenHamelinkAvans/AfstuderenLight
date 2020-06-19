using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using OrderService;
using OrderService.Domain;

namespace OrderServiceTests.Integration
{
    public class OrderControllerTests
    {
        private WebApplicationFactory<TestStartup> factory;

        [SetUp]
        public void Setup()
        {
            factory = new TestWebApplicationFactory<TestStartup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
                });
            });;
        }

        [Test]
        public async Task PlaceOrderWithInvalidCustomer()
        {
            using var client = factory.CreateClient();

            var response =
                await client.PostAsJsonAsync("/Order", new Order() {CustomerId = "noone", Item = "testItem"});

            var orderId = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.IsTrue(string.IsNullOrEmpty(orderId));
        }

        [Test]
        public async Task PlaceOrderSuccess()
        {
            using var client = factory.CreateClient();
            var customerId = "test";
            var response =
                await client.PostAsJsonAsync("/Order", new Order() {CustomerId = customerId, Item = "testItem"});
            response.EnsureSuccessStatusCode();
            
            var orderId = await response.Content.ReadAsStringAsync();

            response = await client.GetAsync($"/Order?customerId={customerId}");
            response.EnsureSuccessStatusCode();

            string orderListString = await response.Content.ReadAsStringAsync();

            var orderList = JsonConvert.DeserializeObject<IEnumerable<Order>>(orderListString).ToList();

            Assert.AreEqual(1, orderList.Count);
            Assert.AreEqual(orderId, orderList[0].Id);
            Assert.AreEqual("testItem", orderList[0].Item);
            Assert.AreEqual(customerId, orderList[0].CustomerId);
        }
    }
}