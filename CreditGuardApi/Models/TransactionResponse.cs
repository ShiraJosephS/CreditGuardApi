namespace CreditGuardApi.Models
{
    public class TransactionResponse: BaseResult
    {
        public TransactionResponse()
        {
            IsValid = true;
            IsFraud = false;
            EncryptedCardNumber = "";
        }

        public string EncryptedCardNumber { get; set; }
        public bool IsFraud { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
