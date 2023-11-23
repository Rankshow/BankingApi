using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApi.Models;

namespace BankingApi.Interfaces
{
    public interface IAccountService
    {
        Account AddAccount(Account account);
        bool DeleteAccount(string accountId);
        Account GetAccountById(string account);
        List<Account> GetAccounts();
        Account UpdateAccount(Account account);
        bool IsExist(string accountId);
    }
}