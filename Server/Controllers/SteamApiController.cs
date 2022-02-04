using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Pekkupekku.Shared.Steam;

namespace Pekkupekku.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SteamApiController : ControllerBase
{
    private readonly ILogger<SteamApiController> _logger;
    private readonly HttpClient _store;
    private readonly HttpClient _community;

    public SteamApiController(ILogger<SteamApiController> logger, IHttpClientFactory factory)
    {
        _logger = logger;
        _store = factory.CreateClient(SteamApiType.Store);
        _community = factory.CreateClient(SteamApiType.Community);
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
            _logger.LogWarning("Could not get tags from Steam");
            return Problem("Could not get tags from Steam.");
        }
        result.Tags = (from t in result.Tags orderby t.Id select t).ToList();
        return Ok(result);
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> SteamStoreSearch(string query)
    {
        // This only proxies the request because of CORS
        var result = await _store.GetAsync($"api/storesearch/?l=english&cc=NO&term={HttpUtility.UrlEncode(query)}");
        if (!result.IsSuccessStatusCode)
        {
            _logger.LogWarning("Search for '{Query}' failed", query);
            return Problem("Search failed.");
        }
        var jsonString = await result.Content.ReadAsStringAsync();
        return Ok(jsonString);
    }
}