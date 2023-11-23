using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dto.Transaction
{
    public class CreateTransactionRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name must be specified.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "TransactionType must be specified.")]
        public string? TransactionType { get; set; }
        [Required(ErrorMessage = "TransactionStatus is required.")]
        public string? TransactionStatus { get; set; }
    }
}