using System.ComponentModel.DataAnnotations;

namespace CineBook2.Models
{
    public class Movie
    {
        [Key] //Primary Key
        public long Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Duration { get; set; }
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
