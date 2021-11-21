using LegendArena.Blazor.HttpClients;
using LegendArena.Models;
using System;
using System.Threading.Tasks;

namespace LegendArena.Blazor.StateContainers
{
  public class PlayerStateContainer
  {
    private Player _player = null;
    public async Task<Player> GetPlayerAsync(PlayerHttpClient playerHttpClient)
    {
      if (_player != null)
        return _player;

      _player = await playerHttpClient.GetOrCreatePlayerAsync(shouldDisplaySnackbar: false);
      NotifyStateChanged();
      return _player;
    }

    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
  }
}
