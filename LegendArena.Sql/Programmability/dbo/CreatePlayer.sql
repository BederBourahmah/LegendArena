CREATE PROCEDURE [dbo].[CreatePlayer]
	@guid UNIQUEIDENTIFIER
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM dbo.Player WHERE Guid = @guid)
		INSERT INTO dbo.Player (Guid) VALUES (@guid);
END
