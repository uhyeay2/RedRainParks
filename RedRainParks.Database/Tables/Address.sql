CREATE TABLE [dbo].[Address] (
    [Id]                   BIGINT           IDENTITY (1, 1) NOT NULL,
    [Guid]                 UNIQUEIDENTIFIER NOT NULL,
    [Line1]                NVARCHAR (MAX)   NULL,
    [Line2]                NVARCHAR (MAX)   NULL,
    [City]                 NVARCHAR (MAX)   NULL,
    [StateId]              INT              NULL,
    [PostalCode]           NVARCHAR (10)    NULL,
    [CreatedAtDateInUTC]   DATETIME2 (7)    DEFAULT (getutcdate()) NULL,
    [LastUpdatedDateInUTC] DATETIME2 (7)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);