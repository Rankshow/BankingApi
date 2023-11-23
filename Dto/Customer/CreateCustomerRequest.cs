using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dto.Customer
{
    public class CreateCustomerRequest
    {
        public Guid Id { set; get; } = Guid.NewGuid();
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public double AccountNo { get; set; }
        [Required]
        public string? Country { get; set; }
    }
}