using System.ComponentModel.DataAnnotations;

namespace CineBook2.Models
{
    public class Theater
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Location { get; set; } = string.Empty;

        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
