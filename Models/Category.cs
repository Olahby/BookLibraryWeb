using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order must be between 1-100!!!")]
        public int DisplayOrder { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
