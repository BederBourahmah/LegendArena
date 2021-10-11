using LegendArena.DataAccess;
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

    public async Task CreatePlayerAsync(Guid guid)
    {
      await _playerAccessor.CreatePlayerAsync(guid);
    }
  }
}
