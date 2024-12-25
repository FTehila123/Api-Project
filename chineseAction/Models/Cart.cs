using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chineseAction.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Present> Presents { get; set; } = new List<Present>();
    }
}
