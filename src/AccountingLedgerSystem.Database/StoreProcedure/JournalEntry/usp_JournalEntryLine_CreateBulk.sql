CREATE PROCEDURE [dbo].[usp_JournalEntryLine_CreateBulk]
    @JournalEntryId INT,
    @Lines dbo.JournalEntryLineType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Calculate totals
        DECLARE @TotalDebit DECIMAL(18,2);
        DECLARE @TotalCredit DECIMAL(18,2);
        
        SELECT 
            @TotalDebit = SUM(Debit),
            @TotalCredit = SUM(Credit)
        FROM @Lines;
        
        -- Validate debits equal credits
        IF @TotalDebit <> @TotalCredit
        BEGIN
            -- Convert decimals to strings for error message
            DECLARE @DebitStr NVARCHAR(50) = CONVERT(NVARCHAR(50), @TotalDebit);
            DECLARE @CreditStr NVARCHAR(50) = CONVERT(NVARCHAR(50), @TotalCredit);
            
            DECLARE @ErrorMessage NVARCHAR(400) = 
                'Journal entry must balance. Total debits (' + @DebitStr + 
                ') must equal total credits (' + @CreditStr + ').';
            
            RAISERROR(@ErrorMessage, 16, 1);
            RETURN;
        END
        
        -- Insert lines
        INSERT INTO JournalEntryLines (JournalEntryId, AccountId, Debit, Credit)
        SELECT 
            @JournalEntryId,
            AccountId,
            Debit,
            Credit
        FROM @Lines;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        THROW;
    END CATCH
END
GO