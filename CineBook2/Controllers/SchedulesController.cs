using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using CineBook2.Services;

namespace CineBook2.Controllers
{
    [ApiController]
    [Route("api/schedules")]
    public class SchedulesController : Controller
    {
        public readonly IScheduleService _scheduleService;
        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet] // GET /api/schedules
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet("{id:long}")] // GET /api/schedules/{id}
        public async Task<IActionResult> GetScheduleById(long id)
        {
            var schedule = await _scheduleService.GetByIdAsync(id);
            if (schedule == null) return NotFound();    
            return Ok(schedule);
        }
    }
}
