using MonolithicApp.Domain;
using MonolithicApp.Repositories;

namespace MonolithicApp.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomer(string id)
        {
            return customerRepository.GetCustomer(id);
        }

        public string CreateCustomer(Customer customer)
        {
            return customerRepository.CreateCustomer(customer);
        }

        public bool Exists(string id)
        {
            return customerRepository.GetCustomer(id) != null;
        }
    }
}