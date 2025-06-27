
            CREATE PROCEDURE [dbo].[usp_CreateAccount]
                @Name NVARCHAR(100),
                @Type INT,
                @Description NVARCHAR(500) = NULL,
                @NewId INT OUTPUT
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO dbo.Accounts (Name, Type, Description, CreatedAt)
                VALUES (@Name, @Type, @Description, GETDATE());

                SET @NewId = SCOPE_IDENTITY();
            END
        
