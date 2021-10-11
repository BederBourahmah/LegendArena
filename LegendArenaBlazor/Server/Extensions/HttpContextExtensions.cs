using Microsoft.AspNetCore.Http;

namespace LegendArena.WebApi.Extensions
{
  public static class HttpContextExtensions
  {
    public static string GetNameIdentifier(this HttpContext httpContext)
      => httpContext.User.FindFirst(claim => claim.Type.Contains("nameidentifier"))?.Value;

    public static string GetDisplayName(this HttpContext httpContext)
      => httpContext.User.FindFirst(claim => claim.Type.Equals("name", System.StringComparison.InvariantCultureIgnoreCase))?.Value;
  }
}
