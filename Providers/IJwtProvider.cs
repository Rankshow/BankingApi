using BankingApi.Identity;

namespace BankingApi.Providers
{
    public interface IJwtProvider
    {
        string Generate (User user);
    }
}