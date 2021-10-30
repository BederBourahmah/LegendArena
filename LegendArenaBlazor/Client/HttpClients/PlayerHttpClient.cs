using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using LegendArena.Model;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using LegendArena.Models;

namespace LegendArena.Blazor.HttpClients
{
  public class PlayerHttpClient
  {
    private readonly HttpClient _http;

    public PlayerHttpClient(HttpClient http)
    {
      _http = http;
    }

    public async Task<Player> GetOrCreatePlayerAsync()
    {
      try
      {
        var response = await _http.PostAsync("Player", null);
        var player = await response.Content.ReadFromJsonAsync<Player>();
        return player;
      }
      catch (AccessTokenNotAvailableException exception)
      {
        exception.Redirect();
        return null;
      }
    }
  }
}
