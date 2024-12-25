using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chineseAction.Models
{
    public class CustomerPresent
    {
        [Key]
        public int Id { get; set; }
        public bool? Status { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        [Required]
        public int? PresentId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("PresentId")]
        public virtual Present? Present { get; set; }
    }
}
