using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapEntitiesService.Controllers;

[ApiController]
[Route("[controller]")]
public class MapEntitiesController : ControllerBase
{
    private readonly IMapEntityService _mapEntitiesControllerService;

    public MapEntitiesController(IMapEntityService mapEntitiesControllerService)
    {
        _mapEntitiesControllerService = mapEntitiesControllerService;
    }
       
    [HttpPost]
    public bool Post([FromBody] MapEntity mapEntity)
    {
        return _mapEntitiesControllerService.AddMapEntity(mapEntity);
    }
}