using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using MudBlazor.Services;
using Blazored.LocalStorage;
using LegendArena.Blazor.HttpClients;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Blazored.SessionStorage;

namespace LegendArena.Blazor
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services
        .AddHttpClient<WeatherForecastHttpClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
        .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
      builder.Services
        .AddHttpClient<PlayerHttpClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
        .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

      builder.Services.AddMsalAuthentication(options =>
      {
        builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
        options.ProviderOptions.DefaultAccessTokenScopes.Add("https://legendarenab2c.onmicrosoft.com/a4c2a214-1771-4a59-b0c7-3f4b97f3f0b3/API.Access");
        options.ProviderOptions.LoginMode = "redirect";
      });

      builder.Services.AddSingleton<SignOutSessionStateManager>();
      builder.Services.AddMudServices();
      builder.Services.AddBlazoredLocalStorage();
      builder.Services.AddBlazoredSessionStorage();
      builder.Services.AddOptions();
      builder.Services.AddAuthorizationCore();

      await builder.Build().RunAsync();
    }
  }
}
