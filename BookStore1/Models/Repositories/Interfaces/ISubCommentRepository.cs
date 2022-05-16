using BookStore1.ViewModels;

namespace BookStore1.Models.Repositories.Interfaces
{
    public interface ISubCommentRepository
    {
        void AddSubComment(BookCommentViewModel bookCommentViewModel, string? userName);
    }
}
