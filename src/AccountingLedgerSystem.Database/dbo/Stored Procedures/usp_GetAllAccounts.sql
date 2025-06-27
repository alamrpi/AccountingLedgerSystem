
            CREATE PROCEDURE [dbo].[usp_GetAllAccounts]
            AS
            BEGIN
                SET NOCOUNT ON;

                SELECT 
                    Id,
                    [Name],
                    [Type],
                    [Description],
                    CreatedAt
                FROM 
                    dbo.Accounts
                ORDER BY 
                    Name;
            END
        
