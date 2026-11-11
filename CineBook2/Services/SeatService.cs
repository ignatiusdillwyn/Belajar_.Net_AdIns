using CineBook2.Repositories;
using CineBook2.Models;
using CineBook2.DTOs;

namespace CineBook2.Services
{
    public class SeatService : ISeatService
    {
        private readonly IRepository<Seat> _seatRepository;

        public SeatService(IRepository<Seat> seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public async Task<List<Seat>> GetByScheduleIdAsync(long scheduleId)
        {
            var seat = await _seatRepository.GetAlllAsync();
            return seat.Where(s => s.ScheduleId == scheduleId).ToList();
        }
    }
}
