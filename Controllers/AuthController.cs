using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApi.Dto.Auth;
using BankingApi.Identity;
using BankingApi.Interfaces;
using BankingApi.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        readonly IJwtProvider _jwtProvider;
        readonly IUserService _userService;
        public AuthController(IJwtProvider jwtProvider, IUserService userService)
        {
            _jwtProvider = jwtProvider;
            _userService = userService;
        }
        [HttpPost]
        [Route("authenticate")]
        public ActionResult<string> Authenticate([FromBody]AuthenticateRequest authRequest)
        {
            var user = new User()
            {
                Username = authRequest.Username,
                Password = authRequest.Password
            };
            var result = _userService.IsCredentialsvalid(user.Username ?? string.Empty, user.Password ?? string.Empty);
            if(!result)
            {
                return Unauthorized();
            }
            var authenticateUser = _userService.GetCredentials(user?.Username ?? string.Empty);
            return _jwtProvider.Generate(authenticateUser);
        }

    }
}