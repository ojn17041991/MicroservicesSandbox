using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; } = string.Empty;

        [Required]
        [ForeignKey("fk_basketid")]
        public int basketid { get; set; }
        // The basket HAS TO be made before the user, so you MUST have the basket ID at this point.
    }
}
