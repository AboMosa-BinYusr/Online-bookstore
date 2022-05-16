using BookStore1.Models.Comments;
using BookStore1.ViewModels;

namespace BookStore1.Models.Repositories.Interfaces
{
    public interface IMainCommentRepository
    {
        void AddMainComment(BookCommentViewModel bookCommentViewModel, string? userName);
    }
}
