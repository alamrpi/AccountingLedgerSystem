using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Core.Interfaces;
using AccountingLedgerSystem.Infrastructure.Data;
using AccountingLedgerSystem.Shared.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace AccountingLedgerSystem.Infrastructure.Repositories
{
    public class JournalEntryRepository : IJournalEntryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<JournalEntryRepository> _logger;

        public JournalEntryRepository(ApplicationDbContext context, ILogger<JournalEntryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<JournalEntry> GetByIdAsync(int id)
        {
            try
            {
                // Get journal entry header
                var entryParameters = new[] { new SqlParameter("@Id", id) };

                var entry = await _context.JournalEntries
                    .FromSqlRaw("EXEC [dbo].[usp_JournalEntry_GetById] @Id", entryParameters)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (entry == null)
                {
                    throw new KeyNotFoundException($"Journal entry with ID {id} not found.");
                }

                // Get journal entry lines
                var lineParameters = new[] { new SqlParameter("@JournalEntryId", id) };
                entry.JournalEntryLines = await _context.JournalEntryLines
                    .FromSqlRaw("EXEC [dbo].[usp_JournalEntryLine_GetByJournalEntryId] @JournalEntryId", lineParameters)
                    .AsNoTracking()
                    .ToListAsync();

                return entry;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting journal entry by ID {Id}", id);
                throw;
            }
        }

        public async Task<PaginatedResult<JournalEntry>> GetPaginatedAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize),
                new SqlParameter("@TotalCount", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

                // Get paginated entries
                var entries = await _context.JournalEntries
                    .FromSqlRaw("EXEC [dbo].[usp_JournalEntry_GetPaginated] @PageNumber, @PageSize, @TotalCount OUTPUT", parameters)
                    .AsNoTracking()
                    .ToListAsync();

                // Get total count from output parameter
                var totalCount = (int)parameters[2].Value;

                return new PaginatedResult<JournalEntry>
                {
                    Items = entries,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting paginated journal entries");
                throw;
            }
        }

        public async Task<int> CreateAsync(JournalEntry journalEntry)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Create journal entry header
                var entryParameters = new[]
                {
                new SqlParameter("@Date", journalEntry.Date),
                new SqlParameter("@Description", journalEntry.Description ?? (object)DBNull.Value),
                new SqlParameter("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [dbo].[usp_JournalEntry_Create] @Date, @Description, @NewId OUTPUT",
                    entryParameters);

                var newId = (int)entryParameters[2].Value;

                // Create lines if any exist
                if (journalEntry.JournalEntryLines.Any())
                {
                    await CreateJournalEntryLinesAsync(newId, journalEntry.JournalEntryLines);
                }

                await transaction.CommitAsync();
                return newId;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error creating journal entry");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var parameters = new[] { new SqlParameter("@Id", id) };
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [dbo].[usp_JournalEntry_Delete] @Id", parameters);

                await transaction.CommitAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error deleting journal entry with ID {Id}", id);
                throw;
            }
        }

        private async Task CreateJournalEntryLinesAsync(int journalEntryId, ICollection<JournalEntryLine> lines)
        {
            // Create DataTable for TVP
            var linesTable = new DataTable();
            linesTable.Columns.Add("AccountId", typeof(int));
            linesTable.Columns.Add("Debit", typeof(decimal));
            linesTable.Columns.Add("Credit", typeof(decimal));

            foreach (var line in lines)
            {
                linesTable.Rows.Add(line.AccountId, line.Debit, line.Credit);
            }

            var parameters = new[]
            {
                new SqlParameter("@JournalEntryId", journalEntryId),
                new SqlParameter("@Lines", SqlDbType.Structured)
                {
                    TypeName = "dbo.JournalEntryLineType",
                    Value = linesTable
                }
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[usp_JournalEntryLine_CreateBulk] @JournalEntryId, @Lines",
                parameters);
        }
    }

}
