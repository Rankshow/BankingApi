

namespace BankingApi.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? TransactionType { get; set; }
        public string? TransactionStatus { get; set; }
    }
}