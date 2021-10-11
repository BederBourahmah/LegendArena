using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using LegendArena.Model;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace LegendArena.Blazor.HttpClients
{
  public class WeatherForecastHttpClient
  {
    private readonly HttpClient _http;

    public WeatherForecastHttpClient(HttpClient http)
    {
      _http = http;
    }

    public async Task<WeatherForecast[]> GetForecastAsync()
    {
      try
      {
        return await _http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
      }
      catch (AccessTokenNotAvailableException exception)
      {
        exception.Redirect();
        return Array.Empty<WeatherForecast>();
      }
    }
  }
}
