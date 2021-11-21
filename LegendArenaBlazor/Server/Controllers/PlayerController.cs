using LegendArena.BusinessLogic;
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
  public class PlayerController : ControllerBase
  {
    private readonly ILogger<PlayerController> _logger;
    private readonly PlayerProcessor _playerProcessor;

    public PlayerController(ILogger<PlayerController> logger, PlayerProcessor playerProcessor)
    {
      _logger = logger;
      _playerProcessor = playerProcessor;
    }

    [HttpPost]
    public async Task<Player> GetOrCreatePlayerAsync()
    {

      var guidAsString = HttpContext.GetNameIdentifier();
      var guid = new Guid(guidAsString);
      var player = await _playerProcessor.GetOrCreatePlayerByGuidAsync(guid);
      return player;
    }

    [HttpGet("Exception")]
    public void TestException()
    {
      throw new LegendArenaException("This is a custom legend arena exception!");
    }
  }
}
