using LegendArena.DataAccess;
using LegendArena.Models;
using System;
using System.Threading.Tasks;

namespace LegendArena.BusinessLogic
{
  public class PlayerProcessor
  {
    private readonly PlayerAccessor _playerAccessor;
    public PlayerProcessor(PlayerAccessor playerAccessor)
    {
      _playerAccessor = playerAccessor;
    }

    public async Task<Player> GetOrCreatePlayerByGuidAsync(Guid guid)
    {
      var existingPlayer = await GetPlayerByGuidAsync(guid);
      if (existingPlayer != null)
        return existingPlayer;

      await CreatePlayerAsync(guid);
      existingPlayer = await GetPlayerByGuidAsync(guid);
      if (existingPlayer == null)
        throw new Exception("Whoa! Something really bad happened when trying to create a player.");

      return existingPlayer;
    }

    public async Task CreatePlayerAsync(Guid guid)
    {
      await _playerAccessor.CreatePlayerAsync(guid);
    }

    public async Task<Player> GetPlayerByGuidAsync(Guid guid)
    {
      return await _playerAccessor.GetPlayerByGuidAsync(guid);
    }
  }
}
