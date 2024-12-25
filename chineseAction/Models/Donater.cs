using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace chineseAction.Models
{
    public class Donater
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? FullName { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(9)]
        public string? Phone { get; set; }

        [EmailAddress]
        [Required]
        public string? Mail { get; set; }
    }
}
