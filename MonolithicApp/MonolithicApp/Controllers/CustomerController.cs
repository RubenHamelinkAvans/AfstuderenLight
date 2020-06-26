using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonolithicApp.Domain;
using MonolithicApp.Services;

namespace MonolithicApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService customerService;
        private ILogger<CustomerController> logger;
        
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            this.customerService = customerService;
            this.logger = logger;
        }

        [HttpGet]
        public Customer Get(string id)
        {
            logger.LogInformation($"Getting information for customer {id}");
            return customerService.GetCustomer(id);
        }

        [HttpPost]
        public string Create(Customer customer)
        {
            logger.LogInformation($"Creating customer {customer.Name}");
            return customerService.CreateCustomer(customer);
        }
    }
}