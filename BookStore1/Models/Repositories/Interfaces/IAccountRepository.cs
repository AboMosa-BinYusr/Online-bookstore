namespace BookStore1.Models.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account? GetAccount(int? id);
        Account? GetAccount(string userName, string password);
        IEnumerable<Account> GetAccounts();
        void AddAccount(Account account);
    }
}
