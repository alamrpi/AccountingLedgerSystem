using AccountingLedgerSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Seeder
{
    public class JournalEntrySeedData : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
         
            // Seed test journal entries
            builder.HasData(
                GetTestJournalEntries()
            );
        }

        private static IEnumerable<JournalEntry> GetTestJournalEntries()
        {
            var entries = new List<JournalEntry>
        {
            new()
            {
                Id = 1,
                Date = DateTime.Parse("2025-01-15"),
                Description = "Initial capital injection",
                CreatedAt = DateTime.Parse("2023-01-15T09:00:00")
            },
            new()
            {
                Id = 2,
                Date = DateTime.Parse("2025-01-20"),
                Description = "Purchase of inventory",
                CreatedAt = DateTime.Parse("2023-01-20T14:30:00")
            },
            new()
            {
                Id = 3,
                Date = DateTime.Parse("2025-01-25"),
                Description = "Sales revenue",
                CreatedAt = DateTime.Parse("2023-01-25T16:45:00")
            },
            new()
            {
                Id = 4,
                Date = DateTime.Parse("2025-01-31"),
                Description = "Month-end adjustments",
                CreatedAt = DateTime.Parse("2023-01-31T23:59:00")
            }
        };

            return entries;
        }
    }

    public class JournalEntryLineSeedData : IEntityTypeConfiguration<JournalEntryLine>
    {
        public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
        {
            // Seed test journal entry lines
            builder.HasData(
                GetTestJournalEntryLines()
            );
        }

        private static IEnumerable<JournalEntryLine> GetTestJournalEntryLines()
        {
            var lines = new List<JournalEntryLine>
        {
            // Entry 1: Capital injection (DR Cash 1000, CR Capital 1000)
            new() { Id = 1, JournalEntryId = 1, AccountId = 101, Debit = 10000.00m, Credit = 0.00m, CreatedAt = DateTime.Parse("2025-01-15T09:00:00") },
            new() { Id = 2, JournalEntryId = 1, AccountId = 301, Debit = 0.00m, Credit = 10000.00m, CreatedAt = DateTime.Parse("2025-01-15T09:00:00") },
            
            // Entry 2: Inventory purchase (DR Inventory 5000, CR Cash 5000)
            new() { Id = 3, JournalEntryId = 2, AccountId = 102, Debit = 5000.00m, Credit = 0.00m, CreatedAt = DateTime.Parse("2025-01-20T14:30:00") },
            new() { Id = 4, JournalEntryId = 2, AccountId = 101, Debit = 0.00m, Credit = 5000.00m, CreatedAt = DateTime.Parse("2025-01-20T14:30:00") },
            
            // Entry 3: Sales revenue (DR Cash 3000, CR Revenue 3000)
            new() { Id = 5, JournalEntryId = 3, AccountId = 101, Debit = 3000.00m, Credit = 0.00m, CreatedAt = DateTime.Parse("2025-01-25T16:45:00") },
            new() { Id = 6, JournalEntryId = 3, AccountId = 401, Debit = 0.00m, Credit = 3000.00m, CreatedAt = DateTime.Parse("2025-01-25T16:45:00") },
            
            // Entry 4: Month-end adjustments (DR Expense 1000, CR Accruals 1000)
            new() { Id = 7, JournalEntryId = 4, AccountId = 501, Debit = 1000.00m, Credit = 0.00m, CreatedAt = DateTime.Parse("2025-01-31T23:59:00") },
            new() { Id = 8, JournalEntryId = 4, AccountId = 203, Debit = 0.00m, Credit = 1000.00m, CreatedAt = DateTime.Parse("2025-01-31T23:59:00") }
        };

            return lines;
        }
    }
}
