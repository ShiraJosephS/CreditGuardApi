using CreditGuardApi.Models;
using FluentValidation;
using CreditGuardApi.Repositories;


namespace CreditGuardApi.Validators
{
    public class TransactionRequestValidator : AbstractValidator<TransactionRequest>
    {
        private IBlacklistRepository _blacklistRepository;
        private ITransactionRepository _transactionRepository;
        private IConfiguration _configuration;
        int maxNumOfInstances;
        int maxTimeInHours;

        public TransactionRequestValidator(IBlacklistRepository blacklistRepository, 
                             ITransactionRepository transactionRepository,
                             IConfiguration configuration)
        {
            _blacklistRepository = blacklistRepository;
            _transactionRepository = transactionRepository;
            _configuration = configuration;
            maxNumOfInstances = Convert.ToInt32(_configuration.GetSection("TransactionList")["MaxNumInstanceValidation"]);
            maxTimeInHours = Convert.ToInt32(_configuration.GetSection("TransactionList")["MaxTimeInHoursValidation"]);

            RuleFor(t => t.CardNumber).NotEmpty().WithMessage("{PropertyName} should be not empty!")
                                      .Must(IsCardInBlackList).WithMessage("{PropertyName} is in Blacklist!")
                                      .Must(IsCardPassLuhnCheck).WithMessage("{PropertyName} did not pass Luhn algorithm validation!")
                                      .Must(IsCardHasTooManyTransactions).WithMessage("{PropertyName} has too many transactions for given period of time!");


        }
        public bool IsCardInBlackList(string cardNum)
        {
            return _blacklistRepository.GetBlacklistByCardNumber(cardNum) != null? false : true;
        }

        public bool IsCardHasTooManyTransactions(string cardNumber)
        {
            List<Transaction> allTransactionsByCardNumber = _transactionRepository.GetTransactionsByCardNumber(cardNumber);
            var latest = DateTime.UtcNow.AddHours(-maxTimeInHours);
            List<Transaction> transactionsInBetween = (from t in allTransactionsByCardNumber where t.TimeStamp >= latest select t).ToList();
            return transactionsInBetween.Count() < maxNumOfInstances; 

        }

        public bool IsCardPassLuhnCheck(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                ).Sum() % 10 == 0;
        }

    }
}
