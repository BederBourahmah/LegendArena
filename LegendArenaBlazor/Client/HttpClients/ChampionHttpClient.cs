using System.Threading.Tasks;
using System.Net.Http;
using LegendArena.Models;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using System;

namespace LegendArena.Blazor.HttpClients
{
  public class ChampionHttpClient : BaseHttpClient
  {
    public ChampionHttpClient(HttpClient http, ISnackbar snackbar, AuthenticationStateProvider authenticationStateProvider) : base(http, snackbar, authenticationStateProvider)
    { }

    public async Task<Champion[]> GetChampionsAsync(bool shouldDisplaySnackbar = true)
    {
      if (!await ValidateUserIsAuthenticatedAsync(shouldDisplaySnackbar: shouldDisplaySnackbar))
        return Array.Empty<Champion>();

      return await GetFromJsonWithErrorSnackbarAsync<Champion[]>("My");
    }
  }
}
