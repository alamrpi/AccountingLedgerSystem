using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Shared.Dto;

namespace AccountingLedgerSystem.Core.Interfaces
{

    public interface IJournalEntryRepository
    {
        Task<JournalEntry> GetByIdAsync(int id);
        Task<PaginatedResult<JournalEntryWithLinesDto>> GetPaginatedAsync(JournalEntriesQueryParams queryParams);
        Task<int> CreateAsync(JournalEntry journalEntry);
        Task<bool> DeleteAsync(int id);
    }
}
