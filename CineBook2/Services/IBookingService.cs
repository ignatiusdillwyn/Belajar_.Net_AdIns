using CineBook2.DTOs;
using CineBook2.Models;
namespace CineBook2.Services
{
    public interface IBookingService
    {
        Task<Booking?> GetByIdAsync(long id);
        Task<List<Booking>> GetAllAsync(string? status, DateTime? date);
        Task<BookingDetailResponse> CreateAsync(CreateBookingRequest request);
        Task<BookingDetailResponse> UpdateAsync(long id, CreateBookingRequest request);
        Task<bool> CancelAsync(long id);
        BookingDetailResponse ToDetailResponse(Booking booking);
    }
}
