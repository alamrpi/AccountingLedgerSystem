using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_usp_GetAllAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[usp_GetAllAccounts]
            AS
            BEGIN
                SET NOCOUNT ON;

                SELECT 
                    Id,
                    [Name],
                    [Type],
                    [Description],
                    CreatedAt
                FROM 
                    dbo.Accounts
                ORDER BY 
                    Name;
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[usp_GetAllAccounts];");
        }
    }
}
