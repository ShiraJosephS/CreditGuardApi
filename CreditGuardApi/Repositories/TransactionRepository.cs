using CreditGuardApi.Models;
namespace CreditGuardApi.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        List<Transaction> transactionlist = new List<Transaction>
       {
            new Transaction("54366541",DateTime.UtcNow),
            new Transaction("54366541",new DateTime(2022,05,08,8,22,20,DateTimeKind.Utc)),
            new Transaction("54366541",new DateTime(2022,05,08,8,22,20,DateTimeKind.Utc)),
            new Transaction("54366541",new DateTime(2022,05,08,8,22,20,DateTimeKind.Utc)),
            new Transaction("54366541",new DateTime(2022,05,08,8,22,20,DateTimeKind.Utc)),
            new Transaction("54366541",new DateTime(2022,05,08,8,22,20,DateTimeKind.Utc)),
            new Transaction("54366541",new DateTime(2022,05,08,8,22,20,DateTimeKind.Utc)),
       };
        public void AddTransaction(Transaction transaction)
        { 
            transactionlist.Add(transaction);
        }

        public List<Transaction> GetTransactions()
        {
            return transactionlist;
        }

        public List<Transaction> GetTransactionsByCardNumber(string cardNumber)
        {
            return transactionlist.Where(c=>c.CardNumber.Equals(cardNumber)).ToList();
        }

    }
}
