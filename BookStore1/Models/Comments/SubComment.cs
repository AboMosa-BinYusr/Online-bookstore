using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore1.Models.Comments
{
    public class SubComment : Comment
    {
        [ForeignKey("MainComment")]
        public int MainCommentId { get; set; }
    }
}
