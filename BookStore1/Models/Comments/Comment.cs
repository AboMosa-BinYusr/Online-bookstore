using System.ComponentModel.DataAnnotations;

namespace BookStore1.Models.Comments
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? CommentText { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
