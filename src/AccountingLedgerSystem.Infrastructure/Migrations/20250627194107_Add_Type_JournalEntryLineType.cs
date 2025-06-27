using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Type_JournalEntryLineType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TYPE [dbo].[JournalEntryLineType] AS TABLE
            (
                [AccountId] INT NOT NULL,
                [Debit] DECIMAL(18,2) NOT NULL,
                [Credit] DECIMAL(18,2) NOT NULL,
                PRIMARY KEY (AccountId)
            )
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TYPE IF EXISTS [dbo].[JournalEntryLineType];");
        }
    }
}
