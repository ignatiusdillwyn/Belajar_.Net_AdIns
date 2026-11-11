using CineBook2.Models;
using CineBook2.Repositories;
using CineBook2.DTOs;

namespace CineBook2.Services
{
    public class BookingService : IBookingService
    {

        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<BookingSeat> _bookingSeatRepository;
        private readonly IRepository<Seat> _seatRepository;

        public BookingService(IRepository<Booking> bookingRepository, 
            IRepository<BookingSeat> bookingSeatRepository, 
            IRepository<Seat> seatRepository)
        {
            _bookingRepository = bookingRepository;
            _bookingSeatRepository = bookingSeatRepository;
            _seatRepository = seatRepository;
        }

        private static BookingDetailResponse ToDetailResponse (Booking booking)
        {
            return new BookingDetailResponse
            {
                Id = booking.Id,
                UserId = booking.UserId,
                ScheduleId = booking.ScheduleId,
                MovieTitle = booking.Schedule?.Movie?.Title ?? string.Empty,
                TheaterName = booking.Schedule?.Theater?.Name ?? string.Empty,
                StartTime = booking.Schedule?.StartTime ?? default,
                TotalTickets = booking.TotalTickets,
                TotalPrices = booking.TotalPrice,
                Status = booking.Status.ToString(),
            };
        }

        public Task<bool> CancelAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingDetailResponse> CreateAsync(CreateBookingRequest request)
        {
            var allSeats = await _seatRepository.GetAlllAsync();
            var requestedSeats = allSeats.Where(s => request.SeatIds.Contains(s.Id)).ToList();

            bool anySeatTaken = requestedSeats.Any(s => !s.IsAvailable);
            if (anySeatTaken || requestedSeats.Count != request.SeatIds.Count)
            {
                return null;
            }

            var booking = new Booking()
            {
                UserId = 1,
                ScheduleId = request.ScheduleId,
                TotalTickets = request.TotalTickets,
                TotalPrice = (int)request.TotalPrice,
                Status = BookingStatus.PENDING,
            };

            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();

            foreach (var seat in requestedSeats)
            {
                seat.IsAvailable = false;
                _seatRepository.UpdateAsync(seat);

                await _bookingSeatRepository.AddAsync(new BookingSeat
                {
                    BookingId = booking.Id,
                    SeatId = seat.Id,   
                });
            }

            await _seatRepository.SaveChangesAsync();
            var created = await GetByIdAsync(booking.Id);
            return created != null ? ToDetailResponse(created) : null;

            throw new NotImplementedException();
        }

        public async Task<List<Booking>> GetAllAsync(string? status, DateTime? date)
        {
            var bookings = await _bookingRepository.GetAlllAsync("Schedule.Movie", "Schedule.Theater");
            if (!string.IsNullOrEmpty(status))
            {
                bookings = bookings.Where(b => b.Status.ToString() == status).ToList();
            }
            return bookings;
        }

        public async Task<Booking?> GetByIdAsync(long id)
        {
            return await _bookingRepository.GetByIdAsync(id, "Schedule.Movie", "Schedule.Theater", "BookingSeat.Seat");
        }

        public Task<BookingDetailResponse> UpdateAsync(long id, CreateBookingRequest request)
        {
            throw new NotImplementedException();
        }

        BookingDetailResponse IBookingService.ToDetailResponse(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
