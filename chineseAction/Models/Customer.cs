using System.ComponentModel.DataAnnotations;

namespace chineseAction.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FullName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Password { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(9)]
        public string? Phone { get; set; }
        [EmailAddress]
        [Required]
        public string? Mail { get; set; }

    }
}
