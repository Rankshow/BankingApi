using BankingApi.Identity;
using BankingApi.Interfaces;

namespace BankingApi.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;
        public UserService(List<User> users)
        {
            _users = users;
        }
        public User GetCredentials(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsCredentialsvalid(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}