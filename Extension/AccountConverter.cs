using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApi.Dto;
using BankingApi.Models;

namespace BankingApi.Extension
{
    public static class AccountConverter
    {
        public static AccountDto AccountToAccountDto(this Account account)
        {
            return new AccountDto()
            {
                Id = account.Id,
                Name = account.Name,
                AccountType = account.AccountType,
            };
        }
    }
}