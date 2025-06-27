using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    public partial class Add_usp_CreateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[usp_CreateAccount]
                @Name NVARCHAR(100),
                @Type INT,
                @Description NVARCHAR(500) = NULL,
                @NewId INT OUTPUT
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO dbo.Accounts (Name, Type, Description, CreatedAt)
                VALUES (@Name, @Type, @Description, GETDATE());

                SET @NewId = SCOPE_IDENTITY();
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[usp_CreateAccount];");
        }
    }
}
