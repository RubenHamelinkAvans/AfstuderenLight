using MonolithicApp.Domain;

namespace MonolithicApp.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string id);
        string CreateCustomer(Customer customer);
    }
}