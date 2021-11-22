CREATE PROCEDURE [dbo].[GetChampionsByPlayerGuid]
	@guid UNIQUEIDENTIFIER
AS
BEGIN
	SELECT
		champ.ChampionId,
		champ.[Name],
		champ.PlayerId
	FROM dbo.Champion champ
	INNER JOIN dbo.Player player ON champ.PlayerId = player.PlayerId
	WHERE player.Guid = @guid
END
