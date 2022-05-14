using BookStore1.Models.Comments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore1.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Author { get; set; } = "Unknown";
        [Required]
        public int Price { get; set; }
        public string? imageURL { get; set; }
        public List<MainComment>? MainComments { get; set; }
        [NotMapped]
        public IFormFile? Image { set; get; }
    }
}
