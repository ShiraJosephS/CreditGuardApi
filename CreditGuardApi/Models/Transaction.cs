namespace CreditGuardApi.Models
{
    public class Transaction
    {
        public Transaction(string _cardNumber, DateTime _timeStamp)
        {
            CardNumber = _cardNumber;
            TimeStamp = _timeStamp;
        }
        public Transaction()
        {
            CardNumber = "";
            TimeStamp =DateTime.UtcNow;
        }
        public string CardNumber { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
