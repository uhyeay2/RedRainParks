CREATE TABLE [dbo].[ExceptionLog]
(
	[Id] BIGINT NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
    [CreatedAtDateInUTC]   DATETIME2 (7)    DEFAULT (getutcdate()) NOT NULL,
	[CreatedBy] VARCHAR(MAX),
	[RequestHeaders] NVARCHAR(MAX),
	[RequestBody] NVARCHAR(MAX),
	[Message] NVARCHAR(MAX),
	[Source] NVARCHAR(MAX),
	[StackTrace] NVARCHAR(MAX)
)
