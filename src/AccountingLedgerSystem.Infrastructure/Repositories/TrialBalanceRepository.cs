using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Core.Interfaces;
using AccountingLedgerSystem.Infrastructure.Data;
using AccountingLedgerSystem.Infrastructure.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Infrastructure.Repositories
{
    public class TrialBalanceRepository : ITrialBalanceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TrialBalanceRepository> _logger;

        public TrialBalanceRepository(
            ApplicationDbContext context,
            ILogger<TrialBalanceRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<TrialBalanceItem>> GetTrialBalanceAsync(DateTime? asOfDate = null, bool includeZeroBalances = false)
        {
            try
            {
                _logger.LogInformation("Fetching trial balance data as of {AsOfDate}", asOfDate);

                var parameters = new[]
                {
                    new SqlParameter("@AsOfDate", asOfDate ?? (object)DBNull.Value),
                    new SqlParameter("@IncludeZeroBalances", includeZeroBalances)
                };

                // Using raw SQL execution with a DbDataReader
                var items = new List<TrialBalanceItem>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_GenerateTrialBalance";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);

                    await _context.Database.OpenConnectionAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        items = await reader.ToListAsync<TrialBalanceItem>();
                    }
                }

                _logger.LogInformation("Successfully retrieved {Count} trial balance items", items.Count);
                return items;
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Database error while fetching trial balance");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching trial balance");
                throw;
            }
        }
    }
}