using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankingApi.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BankingApi.Providers
{
    public class JwtProvider : IJwtProvider
    {
        // This class helps us to convert our user info to token, with the help of option reference
        JwtOptions _options;
        IConfiguration _configuration;
        public JwtProvider(IConfiguration configuration)
        {
            _options = new JwtOptions();
            _configuration = configuration;
            _options.SigningKey = _configuration.GetValue<string>("JwtOptions:SigningKey");
            _options.Audience = _configuration.GetValue<string>("JwtOptions:Audience");
            _options.Issuer = _configuration.GetValue<string>("JwtOptions:Issuer");

            _configuration.GetSection("JwtOptions:SigningKey");
            Console.WriteLine("SigningKey:" + _options.SigningKey);
            Console.WriteLine("Audience:" + _options.Audience);
            Console.WriteLine("Issuer:" + _options.Issuer);
        }

        public string Generate(User user)
        {
           var claim = new Claim[]
           {
                new (ClaimTypes.Email, user.Email ?? string.Empty),
                new (ClaimTypes.Name, user.FirstName ?? string.Empty)
           };
            var SigningKey = new SigningCredentials( new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey ?? string.Empty)), 
            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claim,
                null,
                DateTime.UtcNow.AddHours(4), SigningKey);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}