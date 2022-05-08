namespace CreditGuardApi.Models
{
    public class BaseResult
    {
        public bool IsValid { get; set; }
        public List<string> ValidationMessages{ get; set; }

        public BaseResult()
        {
            ValidationMessages = new List<string>();
        }
    }
}
