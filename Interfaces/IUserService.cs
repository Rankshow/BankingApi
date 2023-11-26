using BankingApi.Identity;

namespace BankingApi.Interfaces
{
    public interface IUserService
    {
       bool IsCredentialsvalid(string username, string password);
       User GetCredentials(string username);
    }
}