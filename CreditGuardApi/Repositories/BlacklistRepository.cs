using CreditGuardApi.Models;
namespace CreditGuardApi.Repositories
{
    public class BlacklistRepository: IBlacklistRepository
    {
        List<string> blacklist = new List<string>
       {
            "54366541",
            "54366541",
            "5436654",
            "5436654",
            "5436654",
            "5436654",
            "5436654",
       };
        public List<string> GetBlacklist()
        {
            return blacklist;
        }
        public string GetBlacklistByCardNumber(string cardNumber)
        {
            return blacklist.Where(c=> c.Equals(cardNumber)).FirstOrDefault();
        }
    }
}
