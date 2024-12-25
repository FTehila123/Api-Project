using System.ComponentModel.DataAnnotations;

namespace chineseAction.Models
{
    public class Maneger
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Password { get; set; }
    }
}
