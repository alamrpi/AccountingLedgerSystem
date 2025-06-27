CREATE TABLE [dbo].[JournalEntries] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME2 (7)  NOT NULL,
    [Description] NVARCHAR (200) DEFAULT (N'') NOT NULL,
    [CreatedAt]   DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_JournalEntries] PRIMARY KEY CLUSTERED ([Id] ASC)
);

