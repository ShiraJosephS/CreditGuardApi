namespace CreditGuardApi.Models
{
    public class TransactionRequest
    {
        public TransactionRequest()
        {
            CardNumber = "";
        }
        public TransactionRequest(string _cardNumber)
        {
            CardNumber = _cardNumber;
        }
        public string CardNumber { get; set; }
        
    }
}
