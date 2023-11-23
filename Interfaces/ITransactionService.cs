using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using BankingApi.Models;

namespace BankingApi.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions();
        Transaction AddTransaction(Transaction transaction);
        bool TransactionById(string transactionId);
        Transaction UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(string transactionId);
        bool IsExist(string transaction);
    }
}