// using System.Net;
// using System.Transactions;
// using BankingApi.Dto.Transaction;
// using BankingApi.Interfaces;
// using Microsoft.AspNetCore.Mvc;

// namespace BankingApi.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class TransactionController : ControllerBase
//     {
//         private readonly ITransactionService _transactionService;
//         private readonly ILogger<TransactionController> _logger;
//         public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
//         {
//             _transactionService = transactionService;
//             _logger = logger;
//         }

//     //* Implementing All endpoint
//         [HttpGet]
//         [Route("AllTransaction")]
//         public ActionResult<List<Transaction>> GetTransactions()
//         {
//             _logger.LogInformation("Executing GetAllTransaction");
//             return _transactionService.GetTransactions;
//         }

//         [HttpPost]
//         [Route("add")]
//         public ActionResult<Transaction> AddTransaction([FromBody]CreateTransactionRequest transactionReq)
//         {
//             _logger.LogInformation("Executing AddTransaction");
//             if(!ModelState.IsValid)
//             {
//                 return BadRequest();
//             }
//             var newTransaction = Transaction
//             {
//                 // Id = transactionReq.Id,
//             }
            
//         }
//     }
// }