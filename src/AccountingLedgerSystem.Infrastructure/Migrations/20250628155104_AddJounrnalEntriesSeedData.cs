using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJounrnalEntriesSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JournalEntries",
                columns: new[] { "Id", "CreatedAt", "Date", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Initial capital injection" },
                    { 2, new DateTime(2023, 1, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Purchase of inventory" },
                    { 3, new DateTime(2023, 1, 25, 16, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales revenue" },
                    { 4, new DateTime(2023, 1, 31, 23, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Month-end adjustments" }
                });

            migrationBuilder.InsertData(
                table: "JournalEntryLines",
                columns: new[] { "Id", "AccountId", "CreatedAt", "Credit", "Debit", "JournalEntryId" },
                values: new object[,]
                {
                    { 1, 101, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 0.00m, 10000.00m, 1 },
                    { 2, 301, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 10000.00m, 0.00m, 1 },
                    { 3, 102, new DateTime(2025, 1, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), 0.00m, 5000.00m, 2 },
                    { 4, 101, new DateTime(2025, 1, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), 5000.00m, 0.00m, 2 },
                    { 5, 101, new DateTime(2025, 1, 25, 16, 45, 0, 0, DateTimeKind.Unspecified), 0.00m, 3000.00m, 3 },
                    { 6, 401, new DateTime(2025, 1, 25, 16, 45, 0, 0, DateTimeKind.Unspecified), 3000.00m, 0.00m, 3 },
                    { 7, 501, new DateTime(2025, 1, 31, 23, 59, 0, 0, DateTimeKind.Unspecified), 0.00m, 1000.00m, 4 },
                    { 8, 203, new DateTime(2025, 1, 31, 23, 59, 0, 0, DateTimeKind.Unspecified), 1000.00m, 0.00m, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JournalEntryLines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
