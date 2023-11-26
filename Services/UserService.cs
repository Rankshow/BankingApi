using BankingApi.Identity;
using BankingApi.Interfaces;

namespace BankingApi.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;
        public UserService()
        {
            _users = UserDb.users;
        }

        public User GetCredentials(string username)
        {
           return _users.Where(s => s.Username == username).First();
        }
        public bool IsCredentialsvalid(string username, string password)
        {
           return _users.Any(p => p.Username == username && p.Password == password);
        }
    }
}