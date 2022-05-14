using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore1.Models.Comments
{
    public class MainComment : Comment
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public List<SubComment>? SubComments { get; set; }
    }
}
