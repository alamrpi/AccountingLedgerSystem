--CREATE OR ALTER PROCEDURE [dbo].[usp_JournalEntry_Create]
--    @Date DATETIME2,
--    @Description NVARCHAR(200) = NULL,
--    @NewId INT OUTPUT
--AS
--BEGIN
--    SET NOCOUNT ON;
    
--    INSERT INTO JournalEntries (Date, Description)
--    VALUES (@Date, @Description);
    
--    SET @NewId = SCOPE_IDENTITY();
--END