
            CREATE PROCEDURE [dbo].[usp_JournalEntry_GetPaginated]
                @PageNumber INT = 1,
                @PageSize INT = 10,
                @SortField NVARCHAR(50) = 'Date',
                @SortDirection NVARCHAR(4) = 'DESC',
                @DateFilter DATE = NULL,
                @TotalCount INT OUTPUT
            AS
            BEGIN
                SET NOCOUNT ON;

                DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
                DECLARE @SQL NVARCHAR(MAX);
                DECLARE @WhereClause NVARCHAR(200) = '';

                IF @DateFilter IS NOT NULL
                BEGIN
                    SET @WhereClause = 'WHERE CAST(A.[Date] AS DATE) = @DateFilter';
                END

                SET @SortField = CASE 
                    WHEN @SortField IN ('Date', 'Description', 'Name', 'Debit', 'Credit', 'Amount') 
                    THEN @SortField 
                    ELSE 'Date' 
                END;

                SET @SortDirection = CASE 
                    WHEN UPPER(@SortDirection) IN ('ASC', 'DESC') 
                    THEN UPPER(@SortDirection) 
                    ELSE 'DESC' 
                END;

                DECLARE @OrderBy NVARCHAR(200) = CASE 
                    WHEN @SortField = 'Name' THEN 'C.[Name]'
                    WHEN @SortField = 'Description' THEN 'A.[Description]'
                    WHEN @SortField = 'Debit' THEN 'B.[Debit]'
                    WHEN @SortField = 'Credit' THEN 'B.[Credit]'
                    WHEN @SortField = 'Amount' THEN 'CASE WHEN B.Debit > 0 THEN B.Debit ELSE B.Credit END'
                    ELSE 'A.[Date]'
                END + ' ' + @SortDirection;

                -- Count
                SET @SQL = N'
                    SELECT @TotalCount = COUNT(*)
                    FROM JournalEntries A
                    INNER JOIN JournalEntryLines B ON A.Id = B.JournalEntryId
                    INNER JOIN Accounts C ON B.AccountId = C.Id
                    ' + @WhereClause;

                EXEC sp_executesql @SQL, 
                    N'@DateFilter DATE, @TotalCount INT OUTPUT', 
                    @DateFilter, @TotalCount OUTPUT;

                -- Page Results
                SET @SQL = N'
                    SELECT 
                        B.Id,
                        A.[Date],
                        A.[Description],
                        C.[Name],
                        B.Credit,
                        B.Debit,
                        A.CreatedAt,
                        CASE WHEN B.Debit > 0 THEN B.Debit ELSE B.Credit END AS Amount
                    FROM 
                        JournalEntries A
                    INNER JOIN JournalEntryLines B ON A.Id = B.JournalEntryId
                    INNER JOIN Accounts C ON B.AccountId = C.Id
                    ' + @WhereClause + '
                    ORDER BY ' + @OrderBy + '
                    OFFSET @Offset ROWS
                    FETCH NEXT @PageSize ROWS ONLY;';

                EXEC sp_executesql @SQL, 
                    N'@Offset INT, @PageSize INT, @DateFilter DATE', 
                    @Offset, @PageSize, @DateFilter;
            END
        
