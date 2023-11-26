namespace BankingApi.Interfaces
{
    public interface IApiKeyValidationService
    {
        bool IsValidApiKey(string userApiKey);
    }
}