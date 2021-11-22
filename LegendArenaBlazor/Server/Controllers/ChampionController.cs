using LegendArena.BusinessLogic;
using LegendArena.DataAccess;
using LegendArena.Model;
using LegendArena.Models;
using LegendArena.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LegendArenaBlazor.Server.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class ChampionController : ControllerBase
  {
    private readonly ILogger<PlayerController> _logger;
    private readonly ChampionAccessor _championAccessor;

    public ChampionController(ILogger<PlayerController> logger, ChampionAccessor championAccessor)
    {
      _logger = logger;
      _championAccessor = championAccessor;
    }

    [HttpGet("My")]
    public async Task<Champion[]> GetChampionsByPlayerIdAsync()
    {
      var guidAsString = HttpContext.GetNameIdentifier();
      var guid = new Guid(guidAsString);
      return await _championAccessor.GetChampionsByPlayerIdAsync(guid);
    }
  }
}
