using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Interfaces
{
    public interface IApiKeyValidationService
    {
        bool IsValidApiKey(string userApiKey);
    }
}