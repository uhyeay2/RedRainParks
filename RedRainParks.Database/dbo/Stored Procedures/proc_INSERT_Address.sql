CREATE PROCEDURE [dbo].[proc_INSERT_Address]
	@Guid UNIQUEIDENTIFIER,
	@Line1 NVARCHAR(MAX),
	@Line2 NVARCHAR(MAX),
	@City NVARCHAR(MAX),
	@StateId INT,
	@PostalCode NVARCHAR(10)
AS

	INSERT INTO Address ([Guid], Line1, Line2, City, StateId, PostalCode)
		VALUES (@Guid, @Line1, @Line2, @City, @StateId, @PostalCode)

RETURN 0
