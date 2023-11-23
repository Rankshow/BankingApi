using System.Net;
using BankingApi.Dto;
using BankingApi.Dto.Account;
using BankingApi.Extension;
using BankingApi.Interfaces;
using BankingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult<Account> AddAccount([FromBody]CreateAccountRequest accountReq)
        {
            _logger.LogInformation("Executing AddAccount");
            if(!ModelState.IsValid)
            {
                return BadRequest();
            };
            var newAccount = new Account
            {
                Id = accountReq.Id,
                Name = accountReq.Name,
                AccountType = accountReq.AccountType
            };
            var Created = _accountService.AddAccount(newAccount);
            return Ok(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("All")]
        public ActionResult<List<Account>> GetAccounts()
        {
            _logger.LogInformation("Executing GetAccounts");
            return _accountService.GetAccounts();
        }

        [HttpGet]
        [Route("GetById/{accountId}")]
        public ActionResult<GenericResponse<AccountDto>> GetAccountById(string accountId)
        {
            _logger.LogInformation("Executing GetById");
            if(_accountService.IsExist(accountId))
            {
                return NotFound($"The accpouny Id { accountId } is not found");
            }
            else
            {
                var result = new GenericResponse<AccountDto>()
                {
                    Code = "200",
                    Message = "Successfull",
                    Result = _accountService.GetAccountById(accountId).AccountToAccountDto()
                };
                return Ok(result);
            }
        }

        [HttpDelete]
        [Route("remove/{accountId}")]
        public ActionResult<bool> DeleteAccount(string accountId)
        {
            _logger.LogInformation("Executing DeleteAccount");
            if(_accountService.IsExist(accountId))
            {
                return NotFound($"The account id { accountId } is not found");
            }
            else
            {
                return Ok(_accountService.DeleteAccount(accountId));
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<Account> UpdateAccount([FromBody]UpdateAccountRequest accountRequest)
        {
            _logger.LogInformation("Executing UpdateAccount");
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updatedAccount = new Account
            {
                Id = accountRequest.Id,
                Name = accountRequest.Name,
                AccountType = accountRequest.AccountType
            };
            var update = _accountService.UpdateAccount(updatedAccount);
            return Ok(HttpStatusCode.OK);;
        }
    }
}