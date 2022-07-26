using MapRepositoryService.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapRepositoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapsController : ControllerBase
    {
        private readonly IMapsService _mapsService;

        public record MapDto(string Name, IFormFile File);

        public MapsController(IMapsService mapsService)
        {
            _mapsService = mapsService;
        }

        [HttpPost]
        public bool Post([FromForm] MapDto mapDto)
        {
            //return _mapsControllerService.AddMap(map);
            return true;
        }
    }
}