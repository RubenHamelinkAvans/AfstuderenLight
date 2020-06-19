using OrderService.Services;

namespace OrderServiceTests.Integration
{
    public class TestCustomerService : ICustomerService
    {
        public bool Exists(string id)
        {
            return id != "noone";
        }
    }
}