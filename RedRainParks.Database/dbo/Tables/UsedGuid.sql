CREATE TABLE [dbo].[UsedGuid]
(
	[Id] BIGINT PRIMARY KEY CLUSTERED IDENTITY(1,1),
	[UniqueIdentifier] UNIQUEIDENTIFIER UNIQUE NOT NULL,
	[CreatedAtDateInUTC] DATETIME2 DEFAULT GETUTCDATE()
)
