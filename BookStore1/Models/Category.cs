using System.ComponentModel.DataAnnotations;

namespace BookStore1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        public List<Book>? Books { get; set; } 
    }
}
