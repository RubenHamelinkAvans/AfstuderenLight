using MonolithicApp.Domain;
using MonolithicApp.Repositories;
using MonolithicApp.Services;
using Moq;
using NUnit.Framework;

namespace MonolithicAppTests.Unit.Services
{
    public class CustomerServiceTests
    {
        private CustomerService customerService;
        private Mock<ICustomerRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<ICustomerRepository>();
            repositoryMock.Setup(r => r.CreateCustomer(It.IsAny<Customer>())).Returns("created");
            repositoryMock.Setup(r => r.GetCustomer("test")).Returns(new Customer("test", "testName"));
            repositoryMock.Setup(r => r.GetCustomer("noone")).Returns(null as Customer);
            customerService = new CustomerService(repositoryMock.Object);
        }

        [Test]
        public void CreateCustomerSuccess()
        {
            var id = customerService.CreateCustomer(new Customer());
            Assert.AreEqual("created", id);
            Assert.AreEqual(1, repositoryMock.Invocations.Count);
        }

        [Test]
        public void GetCustomerSuccess()
        {
            var customer = customerService.GetCustomer("test");
            Assert.AreEqual("test", customer.Id);
            Assert.AreEqual("testName", customer.Name);
        }

        [Test]
        public void Exists()
        {
            var exists = customerService.Exists("test");
            Assert.True(exists);
        }

        [Test]
        public void ExistsNot()
        {
            var exists = customerService.Exists("noone");
            Assert.False(exists);
        }
    }
}