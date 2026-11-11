using System.ComponentModel.DataAnnotations;

namespace CineBook2.DTOs
{
    public class CreateBookingRequest
    {
        [Required(ErrorMessage = "ScheduleId Wajib Diisi.")]
        public long ScheduleId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Pilih Kursi Minimal 1.")]

        public List<long> SeatIds { get; set; } = new();

        [Range(1,10, ErrorMessage = "Total Tiket Antara 1 - 10.")]
        public int TotalTickets { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
