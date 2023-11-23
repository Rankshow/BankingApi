using BankingApi.Interfaces;
using BankingApi.Models;

namespace BankingApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly static List<Transaction> transactions = new List<Transaction>()
        {
            new Transaction()
            {
                Id = Guid.NewGuid(),
                Name = "Philip Ray",
                TransactionType = "Curent",
                TransactionStatus = "Successful"
            },
            new Transaction()
            {
                Id = Guid.NewGuid(),
                Name = "Philimon Chop",
                TransactionType = "Savings",
                TransactionStatus = "Void"
            },
            new Transaction()
            {
                Id = Guid.NewGuid(),
                Name = "Jude Ray",
                TransactionType = "Curent",
                TransactionStatus = "Successful"
            },
        };

        public Transaction AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            return transaction;
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
        public bool DeleteTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }


        public bool IsExist(string transaction)
        {
            throw new NotImplementedException();
        }

        public bool TransactionById(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}