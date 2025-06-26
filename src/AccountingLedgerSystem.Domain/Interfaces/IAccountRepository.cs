using AccountingLedgerSystem.Core.Entities;

namespace AccountingLedgerSystem.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<int> CreateAsync(Account account);
    }
}
