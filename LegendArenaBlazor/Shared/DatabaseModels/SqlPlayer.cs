using System;

namespace LegendArena.Models.DatabaseModels
{
  public record SqlPlayer
  {
    public int PlayerId { get; set; }
    public Guid Guid { get; set; }
  }
}
