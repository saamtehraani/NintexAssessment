using Microsoft.AspNetCore.Mvc;
using NintexAssessment.Models;
using NintexAssessment.Services;
using System.Threading.Tasks;

namespace NintexAssessment.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FlightQueryModel flightQueryModel)
        {
            var result = await _flightService.SearchFlight(flightQueryModel);
            if (!result.Succeeded)
                return BadRequest(result);
            return Ok(result.Value);
        }
    }
}
