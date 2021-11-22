using LegendArena.Blazor.HttpClients;
using LegendArena.Models;
using System;
using System.Linq;
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

    private Champion[] _champions = Array.Empty<Champion>();
    public Champion[] Champions
    {
      get => _champions;
    }
    public async Task LoadChampionsAsync(ChampionHttpClient championHttpClient)
    {
      if (_champions.Any())
        return;

      IsLoadingChampions = true;
      NotifyStateChanged();
      var fetchedChampions = await championHttpClient.GetChampionsAsync(shouldDisplaySnackbar: false);
      if (fetchedChampions?.Any() == true)
        _champions = fetchedChampions;

      IsLoadingChampions = false;
      NotifyStateChanged();
    }

    public bool IsLoadingChampions { get; private set; }

    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
  }
}
