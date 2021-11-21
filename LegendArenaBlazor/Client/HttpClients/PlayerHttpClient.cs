using System.Threading.Tasks;
using System.Net.Http;
using LegendArena.Models;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;

namespace LegendArena.Blazor.HttpClients
{
  public class PlayerHttpClient : BaseHttpClient
  {
    public PlayerHttpClient(HttpClient http, ISnackbar snackbar, AuthenticationStateProvider authenticationStateProvider) : base(http, snackbar, authenticationStateProvider)
    { }

    public async Task<Player> GetOrCreatePlayerAsync(bool shouldDisplaySnackbar = true)
    {
      if (!await ValidateUserIsAuthenticatedAsync(shouldDisplaySnackbar: shouldDisplaySnackbar))
        return null;

      return await PostWithErrorSnackbarAsync<Player>("Player", null);
    }

    public async Task TestExceptionAsync()
    {
      if (!await ValidateUserIsAuthenticatedAsync())
        return;

      await GetWithErrorSnackbarAsync("Player/Exception");
    }
  }
}
