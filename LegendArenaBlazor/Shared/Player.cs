using System;

namespace LegendArena.Models
{
  public class Player
  {
    public Player(int playerId, Guid guid)
    {
      PlayerId = playerId;
      Guid = guid;
    }

    public int PlayerId { get; private set; }
    public Guid Guid { get; private set; }
  }
}
