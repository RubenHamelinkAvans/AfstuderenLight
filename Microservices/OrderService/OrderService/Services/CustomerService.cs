using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderService.Services
{
    public class CustomerService : ICustomerService
    {
        private IConfiguration configuration;

        public CustomerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public bool Exists(string id)
        {
            string address = configuration["CustomerServiceAddress"];
            using HttpClient client = new HttpClient();
            string url = $"http://{address}/Customer?id={id}";
            var customerStringTask = client.GetStringAsync(url);
            customerStringTask.Wait();
            var customerString = customerStringTask.Result;
            return !string.IsNullOrEmpty(customerString);
        }
    }
}