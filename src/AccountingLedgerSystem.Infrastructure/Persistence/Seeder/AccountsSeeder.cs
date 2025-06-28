using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Seeder
{
    public class AccountsSeeder : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // Seed inventory asset accounts
            builder.HasData(
                GetAccounts()
            );
        }

        private static IEnumerable<Account> GetAccounts()
        {
            var accounts = new List<Account>
        {
            //asset accounts
            new() { Id = 100, Name = "Raw Materials", Type = AccountType.Asset, Description = "Raw materials held for production" },
            new() { Id = 101, Name = "Work In Progress", Type = AccountType.Asset, Description = "Goods in the production process" },
            new() { Id = 102, Name = "Finished Goods", Type = AccountType.Asset, Description = "Completed products ready for sale" },
            new() { Id = 103, Name = "Trading Goods", Type = AccountType.Asset, Description = "Goods purchased for resale" },
            new() { Id = 104, Name = "Packing Materials", Type = AccountType.Asset, Description = "Materials used for product packaging" },
            new() { Id = 105, Name = "Store & Spare parts", Type = AccountType.Asset, Description = "Spare parts for maintenance" },
            new() { Id = 106, Name = "Goods in Transit", Type = AccountType.Asset, Description = "Inventory in shipment" },
            new() { Id = 107, Name = "Stationery Items", Type = AccountType.Asset, Description = "Office stationery supplies" },
            new() { Id = 108, Name = "Consumable Items", Type = AccountType.Asset, Description = "Consumable supplies" },
            //liability accounts
            new() {
                Id = 200,
                Name = "Short Term Loan",
                Type = AccountType.Liability,
                Description = "Current portion of long-term debt and short-term borrowings",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 201,
                Name = "Trade Payable",
                Type = AccountType.Liability,
                Description = "Amounts owed to suppliers for goods/services purchased on credit",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 202,
                Name = "Tax & VAT Payable",
                Type = AccountType.Liability,
                Description = "Outstanding tax and value-added tax liabilities",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 203,
                Name = "Provision & Accrual",
                Type = AccountType.Liability,
                Description = "Estimated liabilities and accrued expenses",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },

            //equity accounts
            new() {
                Id = 300,
                Name = "Share Capital",
                Type = AccountType.Equity,
                Description = "Ordinary share capital at nominal value",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 301,
                Name = "Share Premium",
                Type = AccountType.Equity,
                Description = "Amount received above nominal share value",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 302,
                Name = "Retained Earnings",
                Type = AccountType.Equity,
                Description = "Cumulative net earnings not distributed as dividends",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 304,
                Name = "Opening Balance Equity",
                Type = AccountType.Equity,
                Description = "Initial balance when setting up accounting system",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },

            //revenue accounts
             new() {
                Id = 400,
                Name = "Operating Revenue",
                Type = AccountType.Revenue,
                Description = "Primary revenue from core business operations",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 401,
                Name = "Revenue from Branch",
                Type = AccountType.Revenue,
                Description = "Income generated from branch operations",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 402,
                Name = "Revenue from B2B",
                Type = AccountType.Revenue,
                Description = "Business-to-business sales income",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 403,
                Name = "E-Commerce Revenue",
                Type = AccountType.Revenue,
                Description = "Online sales through electronic channels",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            //expense accounts
             new() {
                Id = 500,
                Name = "Material and Service Cost",
                Type = AccountType.Expense,
                Description = "Direct costs of materials and outsourced services",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 501,
                Name = "Branch Operation Expenses",
                Type = AccountType.Expense,
                Description = "All costs associated with branch operations",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 502,
                Name = "Factory Overhead",
                Type = AccountType.Expense,
                Description = "Indirect manufacturing costs",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            },
            new() {
                Id = 503,
                Name = "Settling Expenses",
                Type = AccountType.Expense,
                Description = "Costs related to transaction settlements",
                CreatedAt = DateTime.Parse("2023-01-01T00:00:00Z")
            }
        };

            // Set consistent creation date
            var createdAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            foreach (var account in accounts)
            {
                account.CreatedAt = createdAt;
            }

            return accounts;
        }
    }

}
