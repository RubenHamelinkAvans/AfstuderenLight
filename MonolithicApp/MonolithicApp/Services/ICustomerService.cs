using MonolithicApp.Domain;

namespace MonolithicApp.Services
{
    public interface ICustomerService
    {
        Customer GetCustomer(string id);
        string CreateCustomer(Customer customer);
        bool Exists(string id);
    }
}