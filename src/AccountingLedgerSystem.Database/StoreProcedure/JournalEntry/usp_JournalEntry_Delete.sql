--CREATE OR ALTER PROCEDURE [dbo].[usp_JournalEntry_Delete]
--    @Id INT
--AS
--BEGIN
--    SET NOCOUNT ON;
    
--    BEGIN TRANSACTION;
    
--    BEGIN TRY
--        -- First delete lines
--        DELETE FROM JournalEntryLines WHERE JournalEntryId = @Id;
        
--        -- Then delete header
--        DELETE FROM JournalEntries WHERE Id = @Id;
        
--        COMMIT TRANSACTION;
--    END TRY
--    BEGIN CATCH
--        ROLLBACK TRANSACTION;
--        THROW;
--    END CATCH
--END