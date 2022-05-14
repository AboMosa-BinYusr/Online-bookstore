using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore1.Models.Comments
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CommentText { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
