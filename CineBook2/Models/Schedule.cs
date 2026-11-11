using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineBook2.Models
{
    public class Schedule
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Movie))]
        public long MovieId { get; set; }
        public Movie? Movie { get; set; }

        [ForeignKey(nameof(Theater))]
        public long TheaterId { get; set; }
        public Theater? Theater { get; set; }

        public DateTime StartTime { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
