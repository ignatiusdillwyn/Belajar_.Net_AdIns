using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineBook2.Models
{
    public class Booking
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Schedule))]
        public long ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }

        public int TotalTickets { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public int TotalPrice { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.PENDING;

        public ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    }
}
