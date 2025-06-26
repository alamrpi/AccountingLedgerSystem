CREATE OR ALTER PROCEDURE [dbo].[usp_JournalEntry_GetPaginated]
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @TotalCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
    
    SELECT 
        Id,
        Date,
        Description,
        CreatedAt,
        UpdatedAt
    FROM 
        JournalEntries
    ORDER BY 
        Date DESC, Id DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
    
    SELECT @TotalCount = COUNT(*) FROM JournalEntries;
END