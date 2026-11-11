using CineBook2.DTOs;
namespace CineBook2.Services
{
    public interface IScheduleService
    {
        Task<List<ScheduleResponse>> GetAllAsync();
        Task<ScheduleResponse?> GetByIdAsync(long id);
    }
}
