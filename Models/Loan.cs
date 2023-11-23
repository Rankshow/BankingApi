using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Models
{
    public class Loan
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? LoanType { get; set; }
    }
}