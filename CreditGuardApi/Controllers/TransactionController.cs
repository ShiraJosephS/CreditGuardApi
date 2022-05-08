using CreditGuardApi.Models;
using CreditGuardApi.Repositories;
using CreditGuardApi.Services;
using CreditGuardApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CreditGuardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    { 
     
            private readonly ITransactionService _transactionService;
            private readonly IBlacklistRepository _blacklistRepository;
            private readonly ITransactionRepository _transactionRepository;
            private readonly IConfiguration _configuration;


            public TransactionController(ITransactionService transactionService,
                                          IBlacklistRepository blacklistRepository,
                                          ITransactionRepository transactionRepository,
                                          IConfiguration configuration)
            {
                _transactionService = transactionService;
                _blacklistRepository = blacklistRepository;                  
                _transactionRepository = transactionRepository;
                _configuration = configuration;
            }                                                    
            [HttpGet("AddTransaction/{cardNum}")]
            public ActionResult<TransactionResponse> AddTransaction(string cardNum)
            {
                TransactionRequest request = new TransactionRequest(cardNum);
                TransactionRequestValidator validator = new TransactionRequestValidator(_blacklistRepository, _transactionRepository, _configuration);
                List<string> ValidationMessages = new List<string>();
                var response = new TransactionResponse();

                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    response.IsValid = false;
                    response.IsFraud = true;
                    foreach (var failure in validationResult.Errors)
                    {
                        ValidationMessages.Add(failure.ErrorMessage);
                    }
                    response.ValidationMessages = ValidationMessages;
                }                

                var transaction = _transactionService.AddTransaction(request);
                response.EncryptedCardNumber = transaction.CardNumber;
                response.Timestamp = transaction.TimeStamp;

                return response;
            }

        }
    }
    
