using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MonolithicApp;
using MonolithicApp.Domain;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MonolithicAppTests.Integration
{
    public class CustomerController
    {
        private WebApplicationFactory<Startup> factory;

        [SetUp]
        public void Setup()
        {
            factory = new WebApplicationFactory<Startup>();
        }

        [Test]
        public async Task CreateCustomer()
        {
            using var client = factory.CreateClient();

            var response = await client.PostAsJsonAsync("/Customer", new Customer("testName"));
            var customerId = await response.Content.ReadAsStringAsync();
            
            Assert.IsFalse(string.IsNullOrEmpty(customerId));
        }

        [Test]
        public async Task CreateAndGetCustomer()
        {
            using var client = factory.CreateClient();

            var response = await client.PostAsJsonAsync("/Customer", new Customer("testName"));
            var customerId = await response.Content.ReadAsStringAsync();

            var customerString = await client.GetStringAsync($"/Customer?id={customerId}");
            var customer = JsonConvert.DeserializeObject<Customer>(customerString);
            
            Assert.AreEqual("testName", customer.Name);
        }
    }
}