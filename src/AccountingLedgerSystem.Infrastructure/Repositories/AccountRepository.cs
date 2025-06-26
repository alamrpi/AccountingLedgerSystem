using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Core.Interfaces;
using AccountingLedgerSystem.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AccountingLedgerSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Account account)
        {
            var parameters = new SqlParameter[]
          {

            new("@Name", account.Name),
            new("@Type", (int)account.Type),
            new("@Description", account.Description ?? (object)DBNull.Value),
            new("@NewId", SqlDbType.Int) { Direction = ParameterDirection.Output }
          };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC [usp_CreateAccount] @Name, @Type, @Description, @NewId OUTPUT",
                parameters);

            return (int)parameters[3].Value;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts
                 .FromSqlRaw("EXEC usp_GetAllAccounts")
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
