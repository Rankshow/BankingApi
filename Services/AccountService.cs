using BankingApi.Interfaces;
using BankingApi.Models;

namespace BankingApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly static List<Account> accounts = new List<Account>()
        {
            new Account()
            {
                Id = 1,
                Name = "Damian Robert",
                AccountType = "Current",
            },
            new Account()
            {
                Id = 2,
                Name = "Simon Gabriel",
                AccountType = "Saving",
            },
            new Account()
            {
                Id = 3,
                Name = "Jude bellingham",
                AccountType = "Current",
            },
        };

        public Account AddAccount(Account account)
        {
            accounts.Add(account);
            return account;
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
        public bool DeleteAccount(string accountId)
        {
            var tobeDeleted = accounts.Where(s => s.Id.ToString() == accountId).SingleOrDefault();
            accounts.Remove(tobeDeleted ?? new Account());
            return true;
        }
        public Account GetAccountById(string accountId)
        {
            var getId = accounts.Where(s => s.Id.ToString() ==accountId).SingleOrDefault();
            return getId ?? new Account(); 
        }

        public Account UpdateAccount(Account account)
        {
            Account updatedAccount = new Account();
            foreach(Account acct in accounts)
            {
               if(acct.Id == account.Id)
               {
                    acct.Name = account.Name;
                    acct.AccountType = account.AccountType;
                    updatedAccount = acct;
                    break;
               }
            }
            return updatedAccount;
        }
        public bool IsExist(string accountId)
        {
            var existed = accounts.Where(s => s.Id.ToString() == accountId).SingleOrDefault();
            return existed == null ? true : false;
        }
    }
}
