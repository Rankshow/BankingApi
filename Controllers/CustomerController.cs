using BankingApi.Interfaces;
using BankingApi.Models;
using BankingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public void CreateCustomer([FromBody]Customer customer)
        {
            _customerService.AddCustomer(customer);
        }
        
        [HttpGet]
        [Route("AllCustomers")]
        public List<Customer> GetCustomers()
        {
            return _customerService.GetCustomers();
        }

        [HttpDelete]
        [Route("remove/{customerId}")]
        public void DeleteCustomer(int customerId)
        {
            _customerService.DeleteCustomer(customerId);
        }

        [HttpGet]
        [Route("GetById/{customerId}")]
        public Customer GetCustomer(int customerId)
        {
            return _customerService.GetCustomerById(customerId);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateCustomer([FromBody]Customer customer)
        {
             _customerService.UpdateCustomer(customer);
        }
    }
}