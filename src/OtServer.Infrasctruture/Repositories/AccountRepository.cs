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

        public int GetAccountsCount()
        {
            return _context.Set<Account>().Count();
        }
    }
}
