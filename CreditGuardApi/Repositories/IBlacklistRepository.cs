using CreditGuardApi.Models;
namespace CreditGuardApi.Repositories
{
    public interface IBlacklistRepository
    {
        public List<string> GetBlacklist();
        public string GetBlacklistByCardNumber(string cardNumber);
        
    }
}
