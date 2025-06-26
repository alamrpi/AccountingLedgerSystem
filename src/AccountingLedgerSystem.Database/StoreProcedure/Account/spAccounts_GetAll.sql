CREATE PROCEDURE [dbo].[usp_GetAllAccounts]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Id,
        Name,
        Type AS AccountType,
        Description
    FROM 
        dbo.Account
    ORDER BY 
        Name;
END
GO