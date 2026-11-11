using Microsoft.AspNetCore.Mvc;
using CineBook2.Services;

namespace CineBook2.Controllers
{
    [ApiController]
    [Route("api/seats")]
    public class SeatsController : Controller
    {
        public readonly ISeatService _seatService;
        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeats([FromQuery] long scheduleId)
        {
            var seats = _seatService.GetByScheduleIdAsync(scheduleId);
            return Ok(seats);
        }
    }
}
