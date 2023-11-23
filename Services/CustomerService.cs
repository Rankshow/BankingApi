using BankingApi.Interfaces;
using BankingApi.Models;

namespace BankingApi.Services
{
    public class CustomerService : ICustomerService
    {
        // In-memory database
        private readonly static List<Customer> customers = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                Name = "George Philip",
                Email = "georgephilip@gmail.com",
                Gender = "Male",
                AccountNo = 3576419051,
                Country = "France"
            },
            new Customer()
            {
                Id = 2,
                Name = "Kelli Aguirre",
                Email = "kaguirre1@fastcompany.com",
                Gender = "Female",
                AccountNo = 5010125318,
                Country = "Canada",

            },
            new Customer()
            {
                Id = 3,
                Name = "Dominic Caldwall",
                Email = "dcaldwall4@symantec.com",
                Gender = "Male",
                AccountNo = 6394684496,
                Country = "Nigeria",
            },
        };
        
        //* All methods implementing the interfaces
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }
        public void DeleteCustomer(int customerId)
        {
           Customer? customer = customers.Where(s => s.Id == customerId).SingleOrDefault();
           customers.Remove(customer ?? new Customer());
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer? customer = customers.Where(s => s.Id == customerId).SingleOrDefault();
            return customer ?? new Customer(); 
        }
        public void UpdateCustomer(Customer newCustomer)
        {
            foreach(Customer cust in customers)
            {
                if(cust.Id == newCustomer.Id)
                {
                    cust.Name = newCustomer.Name;
                    cust.Email = newCustomer.Email;
                    cust.Gender = newCustomer.Gender;
                    cust.AccountNo = newCustomer.AccountNo;
                    cust.Country = newCustomer.Country;
                }
            };
        }
    }
}