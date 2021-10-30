using LegendArena.Models.DatabaseModels;

namespace LegendArena.Models.Extensions
{
  public static class SqlExtensions
  {
    public static Player ToPlayer(this SqlPlayer sqlPlayer)
    {
      return new(playerId: sqlPlayer.PlayerId, guid: sqlPlayer.Guid);
    }
  }
}
