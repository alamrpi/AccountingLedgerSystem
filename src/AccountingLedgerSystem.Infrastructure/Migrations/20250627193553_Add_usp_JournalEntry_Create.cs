using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_usp_JournalEntry_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[usp_JournalEntry_Create]
                @Date DATETIME2,
                @Description NVARCHAR(200) = NULL,
                @NewId INT OUTPUT
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO JournalEntries (Date, Description, CreatedAt)
                VALUES (@Date, @Description, GETDATE());

                SET @NewId = SCOPE_IDENTITY();
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[usp_JournalEntry_Create];");
        }
    }
}
