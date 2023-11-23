using BankingApi.Models;

namespace BankingApi.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        List<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
    }
}