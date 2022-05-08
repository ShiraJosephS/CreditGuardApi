using CreditGuardApi.Models;
namespace CreditGuardApi.Repositories
{
    public interface ITransactionRepository
    {
        public void AddTransaction(Transaction trans);
        public List<Transaction> GetTransactions();
        public List<Transaction> GetTransactionsByCardNumber(string cardNumber);

    }
}
