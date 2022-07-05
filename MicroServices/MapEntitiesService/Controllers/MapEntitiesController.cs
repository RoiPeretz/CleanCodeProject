using Microsoft.AspNetCore.Mvc;

namespace MapEntitiesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapEntitiesController : ControllerBase
    {
        private readonly ILogger<MapEntitiesController> _logger;

        public MapEntitiesController(ILogger<MapEntitiesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }
    }
}