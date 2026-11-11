using CineBook2.Repositories;
    using CineBook2.Models;
using CineBook2.DTOs;
namespace CineBook2.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _scheduleRepository;

        public ScheduleService(IRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<ScheduleResponse>> GetAllAsync()
        {
            List<Schedule> schedules = await _scheduleRepository.GetAlllAsync("Movie", "Theater");
            return schedules.Select(ToResponse).ToList();
        }

        public async Task<ScheduleResponse?> GetByIdAsync(long id)
        {
            Schedule? schedule = await _scheduleRepository.GetByIdAsync(id, "Movie", "Theater");
            return schedule!=null ? ToResponse(schedule) : null;
        }

        private static ScheduleResponse ToResponse(Schedule s) {
            return new ScheduleResponse()
            {
                Id = s.Id,
                MovieId = s.MovieId,
                MovieTitle = s.Movie?.Title ?? string.Empty,
                MovieDescription = s.Movie?.Description ?? string.Empty,
                MovieDuration = s.Movie?.Duration ?? 0,
                TheaterId = s.TheaterId,
                TheaterName = s.Theater?.Name ?? string.Empty,
                TheaterLocation = s.Theater?.Location ?? string.Empty,
                StartTime = s.StartTime,
                Price = s.Price,
            };  
        }


}
}
