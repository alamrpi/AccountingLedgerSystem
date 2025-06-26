CREATE OR ALTER PROCEDURE [dbo].[usp_JournalEntryLine_GetByJournalEntryId]
    @JournalEntryId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Id,
        JournalEntryId,
        AccountId,
        Debit,
        Credit
    FROM 
        JournalEntryLines
    WHERE 
        JournalEntryId = @JournalEntryId;
END