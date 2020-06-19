using MonolithicApp.Domain;
using MonolithicApp.Repositories;
using NUnit.Framework;

namespace MonolithicAppTests.Unit.Repositories
{
    public class CustomerRepositoryTests
    {
        private CustomerRepository customerRepository;
        private string existingId;

        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
            existingId = customerRepository.CreateCustomer(new Customer("existing", "test"));
        }

        [Test]
        public void CreateCustomerSuccess()
        {
            var id = customerRepository.CreateCustomer(new Customer("testName"));
            Assert.IsFalse(string.IsNullOrEmpty(id));
        }

        [Test]
        public void CreateCustomerExisting()
        {
            // given id doesn't matter as the order is assigned a new id
            var id = customerRepository.CreateCustomer(new Customer("existing", "testName"));
            Assert.IsFalse(string.IsNullOrEmpty(id));
        }

        [Test]
        public void GetCustomerExisting()
        {
            var customer = customerRepository.GetCustomer(existingId);
            Assert.AreEqual("test", customer.Name);
        }

        [Test]
        public void GetCustomerNonExisting()
        {
            var customer = customerRepository.GetCustomer("non-existent");
            Assert.IsNull(customer);
        }
    }
}