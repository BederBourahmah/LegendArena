CREATE PROCEDURE [dbo].[sp_GetPlayerByGuid]
	@guid UNIQUEIDENTIFIER
AS
BEGIN
	SELECT TOP(1)
		pl.Guid,
		pl.PlayerId
	FROM dbo.Player pl
	WHERE pl.Guid = @guid
END
