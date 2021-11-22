namespace LegendArena.Models
{
  public class Champion
  {
    public Champion(int playerId, string name, int championId)
    {
      PlayerId = playerId;
      Name = name;
      ChampionId = championId;
    }

    public int PlayerId { get; private set; }
    public string Name { get; private set; }
    public int ChampionId { get; private set; }
  }
}
