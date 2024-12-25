using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace chineseAction.Models
{
    public class Present
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public int? Price { get; set; }
        public string? Image { get; set; }
        public int? NumBuyers { get; set; }
        [Required]
        public int? DonaterId { get; set; }

        [ForeignKey("DonaterId")]
        public virtual Donater? Donater { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
