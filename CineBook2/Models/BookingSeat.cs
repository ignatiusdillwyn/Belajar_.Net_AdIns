using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineBook2.Models
{
    public class BookingSeat
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Booking))]
        public long BookingId { get; set; }
        public Booking? Booking { get; set; }

        [ForeignKey(nameof(Seat))]
        public long SeatId { get; set; }
        public Seat? Seat { get; set; }
    }
}
