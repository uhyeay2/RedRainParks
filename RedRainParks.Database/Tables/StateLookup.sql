CREATE TABLE [dbo].[StateLookup] (
    [Id] INT PRIMARY KEY CLUSTERED IDENTITY (1, 1) NOT NULL,
    [Abbreviation] VARCHAR(2) NOT NULL,
    [EnglishDisplay] NVARCHAR(MAX) NULL,
    [SpanishDisplay] NVARCHAR(MAX) NULL,
);