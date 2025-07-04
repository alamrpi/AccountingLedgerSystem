﻿CREATE TABLE [dbo].[Accounts] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Type]        INT            NOT NULL,
    [Description] NVARCHAR (500) NULL,
    [CreatedAt]   DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

