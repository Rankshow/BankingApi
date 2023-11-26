using BankingApi.Identity;

namespace BankingApi.Interfaces
{
    public interface IUserService
    {
       bool IsCredentialsvalid(string userName, string password);
       User GetCredentials(string username);
    }
}