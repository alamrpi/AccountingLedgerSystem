using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingLedgerSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_usp_JournalEntryLine_CreateBulk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE [dbo].[usp_JournalEntryLine_CreateBulk]
                @JournalEntryId INT,
                @Lines dbo.JournalEntryLineType READONLY
            AS
            BEGIN
                SET NOCOUNT ON;

                BEGIN TRANSACTION;

                BEGIN TRY
                    DECLARE @TotalDebit DECIMAL(18,2);
                    DECLARE @TotalCredit DECIMAL(18,2);

                    SELECT 
                        @TotalDebit = SUM(Debit),
                        @TotalCredit = SUM(Credit)
                    FROM @Lines;

                    IF @TotalDebit <> @TotalCredit
                    BEGIN
                        DECLARE @DebitStr NVARCHAR(50) = CONVERT(NVARCHAR(50), @TotalDebit);
                        DECLARE @CreditStr NVARCHAR(50) = CONVERT(NVARCHAR(50), @TotalCredit);

                        DECLARE @ErrorMessage NVARCHAR(400) = 
                            'Journal entry must balance. Total debits (' + @DebitStr + 
                            ') must equal total credits (' + @CreditStr + ').';

                        RAISERROR(@ErrorMessage, 16, 1);
                        RETURN;
                    END

                    INSERT INTO JournalEntryLines (JournalEntryId, AccountId, Debit, Credit, CreatedAt)
                    SELECT 
                        @JournalEntryId,
                        AccountId,
                        Debit,
                        Credit,
                        GETDATE()
                    FROM @Lines;

                    COMMIT TRANSACTION;
                END TRY
                BEGIN CATCH
                    IF @@TRANCOUNT > 0
                        ROLLBACK TRANSACTION;

                    THROW;
                END CATCH
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[usp_JournalEntryLine_CreateBulk];");
        }
    }
}
