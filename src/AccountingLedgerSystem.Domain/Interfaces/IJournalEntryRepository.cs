using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Shared.Dto;

namespace AccountingLedgerSystem.Core.Interfaces
{

    public interface IJournalEntryRepository
    {
        Task<JournalEntry> GetByIdAsync(int id);
        Task<PaginatedResult<JournalEntry>> GetPaginatedAsync(int pageNumber = 1, int pageSize = 10);
        Task<int> CreateAsync(JournalEntry journalEntry);
        Task<bool> DeleteAsync(int id);
    }
}
