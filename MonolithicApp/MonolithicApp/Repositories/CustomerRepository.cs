using System;
using System.Collections.Generic;
using System.Linq;
using MonolithicApp.Domain;

namespace MonolithicApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>
            {
                {new Customer("0", "Piet")},
                {new Customer("1", "Henk")},
                {new Customer("2", "Kees")},
            };
        }
        
        public Customer GetCustomer(string id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public string CreateCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            customers.Add(customer);
            return customer.Id;
        }
    }
}