using MapRepositoryService.Core.Models;
using MapRepositoryService.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapRepositoryService.Controllers;

[ApiController]
[Route("[controller]")]
public partial class MapsController : ControllerBase
{
    private readonly IMapsService _mapsService;

    public MapsController(IMapsService mapsService)
    {
        _mapsService = mapsService;
    }

    public record MapDto(string Name, IFormFile File);
    [HttpPost]
    public ResultModel Post([FromForm] MapDto mapDto)
    {
        var stream = mapDto.File.OpenReadStream();
        var extension = Path.GetExtension(mapDto.Name);
        return _mapsService.AddMap(new MapModel(mapDto.Name, stream, extension));
    }

    [HttpGet(Name = "Map")]
    public ResultModel<string> GetMap([FromBody] string mapName)
    {
        return _mapsService.GetMap(mapName);
    }

    [HttpGet(Name = "Maps")]
    public ResultModel<IEnumerable<string>> GetMaps()
    {
        return _mapsService.GetMaps();
    }

    [HttpDelete]
    public ResultModel Delete([FromBody] string name)
    {
        return _mapsService.DeleteMap(name);
    }
}