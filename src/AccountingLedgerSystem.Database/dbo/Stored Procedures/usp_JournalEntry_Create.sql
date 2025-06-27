
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
        
