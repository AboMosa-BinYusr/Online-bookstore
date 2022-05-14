using BookStore1.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore1.ViewModels
{
    public class BookCommentViewModel
    {
        [Required]
        public Book? Book { get; set; }
        [Required]
        public string? CommentText { get; set; }
        [Required]
        public int CommentIntialId { get; set; } = 0;
    }
}
