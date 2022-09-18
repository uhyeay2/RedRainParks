CREATE TABLE [dbo].[ParkLocationAddress]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY (1, 1),
	[ParkLocationId] INT NOT NULL REFERENCES ParkLocation(Id),
	[AddressId] BIGINT NOT NULL REFERENCES Address(Id),
	[Rank] INT DEFAULT (1),
	[ReferenceName] NVARCHAR(MAX) NOT NULL, 
    [IsActive] TINYINT NULL DEFAULT 1 
)
