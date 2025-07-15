using OtServer.Domain.Entities;

namespace OtServer.Domain.Repositories
{
    public interface IAccountRepository
    {
        int GetAccountsCount();
        Account? GetAccountByAccountNumber(int accountNumber);

        bool HasAccountByEmail(string email);
        bool HasAccountByNumber(int accountNumber);

        void Add(Account account);
        void Update(Account account);

        bool SaveChanges();
    }
}
