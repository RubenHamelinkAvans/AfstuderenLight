using Microsoft.AspNetCore.Mvc;
using MonolithicApp.Domain;
using MonolithicApp.Services;

namespace MonolithicApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public Customer Get(string id)
        {
            return customerService.GetCustomer(id);
        }

        [HttpPost]
        public string Create(Customer customer)
        {
            return customerService.CreateCustomer(customer);
        }
    }
}