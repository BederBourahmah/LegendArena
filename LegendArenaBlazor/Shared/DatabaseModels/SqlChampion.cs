namespace LegendArena.Models.DatabaseModels
{
  public record SqlChampion
  {
    public int PlayerId { get; set; }
    public string Name { get; set; }
    public int ChampionId { get; set; }
  }
}
