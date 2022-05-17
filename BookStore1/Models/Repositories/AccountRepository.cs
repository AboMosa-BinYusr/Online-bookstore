using BookStore1.Data;
using BookStore1.Models.Repositories.Interfaces;

namespace BookStore1.Models.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDataContext _database;

        public AccountRepository(AppDataContext database)
        {
            _database = database;
        }

        public void AddAccount(Account account)
        {
            _database.Accounts.Add(account);
            _database.SaveChanges();
        }

        public Account? GetAccount(string userName, string password)
        {
            return _database.Accounts.Where(acc => acc.UserName == userName && acc.Password == password)
                   .FirstOrDefault();
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _database.Accounts;
        }
    }
}
