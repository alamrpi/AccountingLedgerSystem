CREATE PROCEDURE [dbo].[usp_CreateAccount]
    @Name NVARCHAR(100),
    @Type INT, -- Assuming AccountType is an INT in database
    @Description NVARCHAR(500) = NULL,
    @NewId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.Account (Name, Type, Description)
    VALUES (@Name, @Type, @Description);
    
    SET @NewId = SCOPE_IDENTITY();
END
GO