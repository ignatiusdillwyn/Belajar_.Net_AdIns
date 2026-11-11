using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineBook2.Models
{
    public class Seat
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Schedule))]
        public long ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }

        [Required]
        [MaxLength(10)]
        public string SeatNumber { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = false;

    }
}
