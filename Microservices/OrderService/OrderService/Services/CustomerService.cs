using System.Net.Http;

namespace OrderService.Services
{
    public class CustomerService : ICustomerService
    {
        // TODO call to actual service
        public bool Exists(string id)
        {
            return true;
        }
    }
}