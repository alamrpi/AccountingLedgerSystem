CREATE TYPE [dbo].[JournalEntryLineType] AS TABLE (
    [AccountId] INT             NOT NULL,
    [Debit]     DECIMAL (18, 2) NOT NULL,
    [Credit]    DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountId] ASC));

