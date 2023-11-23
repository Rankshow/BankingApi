
using BankingApi.Interfaces;

namespace BankingApi.Services
{
    public class ApiKeyValidationService : IApiKeyValidationService
    {
        private readonly IConfiguration _configuration;
        public ApiKeyValidationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool IsValidApiKey(string userApiKey)
        {
            if(string.IsNullOrEmpty(userApiKey))
            {
                return false;
            }
            else
            {
                var key = _configuration.GetValue<string>(Constant.AppConstant.ApiKeyHeaderName);
                return Convert.ToBoolean(key?.Equals(userApiKey));
            }
            
        }
    }
}