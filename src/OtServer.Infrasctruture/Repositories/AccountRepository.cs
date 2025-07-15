using Microsoft.EntityFrameworkCore;
using OtServer.Domain.Entities;
using OtServer.Domain.Repositories;

namespace OtServer.Infrasctruture.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Account account)
        {
            _context.Set<Account>().Add(account); 
        }

        public Account? GetAccountByAccountNumber(int accountNumber)
        {
            return _context.Set<Account>().Include(x=>x.Players).FirstOrDefault(x=>x.AccountNumber == accountNumber);
        }

        public int GetAccountsCount()
        {
            return _context.Set<Account>().AsNoTracking().Count();
        }

        public bool HasAccountByEmail(string email)
        {
            return _context.Set<Account>().AsNoTracking().Any(x=>x.Email.ToLower() == email.ToLower());
        }

        public bool HasAccountByNumber(int accountNumber)
        {
            return _context.Set<Account>().AsNoTracking().Any(x => x.AccountNumber == accountNumber);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(Account account)
        {
            _context.Set<Account>().Update(account);
        }
    }
}
