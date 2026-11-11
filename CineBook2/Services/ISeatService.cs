using CineBook2.Models;
namespace CineBook2.Services
{
    public interface ISeatService
    {
        Task<List<Seat>> GetByScheduleIdAsync(long idscheduleId);
    }
}
