using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;

namespace LegendArena.Blazor.HttpClients
{
  public class BaseHttpClient
  {
    private readonly HttpClient _http;
    private readonly ISnackbar _snackbar;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public BaseHttpClient(HttpClient http, ISnackbar snackbar, AuthenticationStateProvider authenticationStateProvider)
    {
      _http = http;
      _snackbar = snackbar;
      _authenticationStateProvider = authenticationStateProvider;
    }

    protected async Task<bool> ValidateUserIsAuthenticatedAsync(bool shouldDisplaySnackbar = true)
    {
      var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
      if (!authState.User.Identity.IsAuthenticated)
      {
        if (shouldDisplaySnackbar)
          _snackbar.Add("You must be logged in.");

        return false;
      }

      return true;
    }

    protected async Task<T> PostWithErrorSnackbarAsync<T>(string requestRoute, HttpContent content)
    {
      try
      {
        var response = await _http.PostAsync(requestRoute, content);
        var responseContent = await response.Content.ReadFromJsonAsync<T>();
        return responseContent;
      }
      catch (AccessTokenNotAvailableException exception)
      {
        exception.Redirect();
        return default;
      }
      catch (Exception exception)
      {
        _snackbar.Add(exception.Message, Severity.Error, config =>
        {
          config.RequireInteraction = true;
          config.SnackbarVariant = Variant.Filled;
        });

        return default;
      }
    }

    protected async Task<T> GetFromJsonWithErrorSnackbarAsync<T>(string requestRoute)
    {
      try
      {
        return await _http.GetFromJsonAsync<T>($"{_http.BaseAddress}/{requestRoute}");
      }
      catch (AccessTokenNotAvailableException exception)
      {
        exception.Redirect();
        return default;
      }
      catch (Exception exception)
      {
        _snackbar.Add(exception.Message, Severity.Error, config =>
        {
          config.RequireInteraction = true;
          config.SnackbarVariant = Variant.Filled;
        });

        return default;
      }
    }

    protected async Task<T> GetWithErrorSnackbarAsync<T>(string requestRoute)
    {
      try
      {
        var response = await _http.GetAsync($"{_http.BaseAddress}/{requestRoute}");
        if (!response.IsSuccessStatusCode)
        {
          var errorMessage = await response.Content.ReadAsStringAsync();
          throw new Exception(errorMessage);
        }

        var responseContent = await response.Content.ReadFromJsonAsync<T>();
        return responseContent;
      }
      catch (AccessTokenNotAvailableException exception)
      {
        exception.Redirect();
        return default;
      }
      catch (Exception exception)
      {
        _snackbar.Add(exception.Message, Severity.Error, config =>
        {
          config.RequireInteraction = true;
          config.SnackbarVariant = Variant.Filled;
        });

        return default;
      }
    }

    protected async Task GetWithErrorSnackbarAsync(string requestRoute)
    {
      try
      {
        var response = await _http.GetAsync(requestRoute);
        if (!response.IsSuccessStatusCode)
        {
          var errorMessage = await response.Content.ReadAsStringAsync();
          throw new Exception(errorMessage);
        }
      }
      catch (AccessTokenNotAvailableException exception)
      {
        exception.Redirect();
      }
      catch (Exception exception)
      {
        _snackbar.Add(exception.Message, Severity.Error, config =>
        {
          config.RequireInteraction = true;
          config.SnackbarVariant = Variant.Filled;
        });
      }
    }
  }
}
