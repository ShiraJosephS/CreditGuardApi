using CreditGuardApi.Models;

namespace CreditGuardApi.Services
{
    public interface ITransactionService
    {
        Transaction AddTransaction(TransactionRequest request);
    }
}
