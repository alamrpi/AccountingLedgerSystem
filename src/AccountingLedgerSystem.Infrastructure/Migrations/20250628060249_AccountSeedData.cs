using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Raw materials held for production", "Raw Materials", 1 },
                    { 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Goods in the production process", "Work In Progress", 1 },
                    { 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Completed products ready for sale", "Finished Goods", 1 },
                    { 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Goods purchased for resale", "Trading Goods", 1 },
                    { 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Materials used for product packaging", "Packing Materials", 1 },
                    { 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Spare parts for maintenance", "Store & Spare parts", 1 },
                    { 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Inventory in shipment", "Goods in Transit", 1 },
                    { 107, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Office stationery supplies", "Stationery Items", 1 },
                    { 108, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Consumable supplies", "Consumable Items", 1 },
                    { 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Current portion of long-term debt and short-term borrowings", "Short Term Loan", 2 },
                    { 201, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Amounts owed to suppliers for goods/services purchased on credit", "Trade Payable", 2 },
                    { 202, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Outstanding tax and value-added tax liabilities", "Tax & VAT Payable", 2 },
                    { 203, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Estimated liabilities and accrued expenses", "Provision & Accrual", 2 },
                    { 300, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ordinary share capital at nominal value", "Share Capital", 3 },
                    { 301, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Amount received above nominal share value", "Share Premium", 3 },
                    { 302, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cumulative net earnings not distributed as dividends", "Retained Earnings", 3 },
                    { 304, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Initial balance when setting up accounting system", "Opening Balance Equity", 3 },
                    { 400, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Primary revenue from core business operations", "Operating Revenue", 4 },
                    { 401, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Income generated from branch operations", "Revenue from Branch", 4 },
                    { 402, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Business-to-business sales income", "Revenue from B2B", 4 },
                    { 403, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Online sales through electronic channels", "E-Commerce Revenue", 4 },
                    { 500, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Direct costs of materials and outsourced services", "Material and Service Cost", 5 },
                    { 501, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "All costs associated with branch operations", "Branch Operation Expenses", 5 },
                    { 502, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Indirect manufacturing costs", "Factory Overhead", 5 },
                    { 503, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Costs related to transaction settlements", "Settling Expenses", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 503);
        }
    }
}
