using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_sp_GetAccountsPaginated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[sp_GetAccountsPaginated]
                @PageNumber INT = 1,
                @PageSize INT = 10
            AS
            BEGIN
                SET NOCOUNT ON;

                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

                SELECT 
                    a.Name,
                    a.Type AS AccountType,
                    a.Description
                FROM 
                    Accounts a
                ORDER BY 
                    a.Name
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY;

                SELECT COUNT(*) AS TotalCount FROM Accounts;
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[sp_GetAccountsPaginated];");
        }
    }
}
