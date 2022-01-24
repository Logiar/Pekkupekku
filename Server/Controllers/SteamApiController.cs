using Microsoft.AspNetCore.Mvc;
using Pekkupekku.Shared;
using Microsoft.AspNetCore.Http;

namespace Pekkupekku.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SteamApiController : ControllerBase
{
    private readonly ILogger<SteamApiController> _logger;
    private readonly HttpClient _store;

    public SteamApiController(ILogger<SteamApiController> logger, IHttpClientFactory factory)
    {
        _logger = logger;
        _store = factory.CreateClient("SteamStoreApi");
    }

    [HttpGet("tags")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> TagsResultGet()
    {
        var result = await _store.GetFromJsonAsync<TagsResult>("actions/ajaxgetstoretags");
        if (result == null)
        {
            _logger.Log(LogLevel.Warning, "Could not get tags from Steam");
            return Problem("Could not get tags from Steam.");
        }
        result.Tags = (from t in result.Tags orderby t.Id select t).ToList();
        return Ok(result);
    }
}