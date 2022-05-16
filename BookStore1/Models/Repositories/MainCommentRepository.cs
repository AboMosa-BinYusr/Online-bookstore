using BookStore1.Data;
using BookStore1.Models.Comments;
using BookStore1.Models.Repositories.Interfaces;
using BookStore1.ViewModels;

namespace BookStore1.Models.Repositories
{
    public class MainCommentRepository : IMainCommentRepository
    {
        private readonly AppDataContext _database;

        public MainCommentRepository(AppDataContext database)
        {
            _database = database;
        }

        public void AddMainComment(BookCommentViewModel bookCommentViewModel, string? userName)
        {
            if (bookCommentViewModel.CommentIntialId == 0)
            {
                _database.MainComments.Add(new MainComment
                {
                    CommentText = bookCommentViewModel.CommentText,
                    BookId = bookCommentViewModel.Book.Id,
                    UserName = userName,
                    CreationDate = DateTime.Now,
                });
                _database.SaveChanges();
            }

        }
    }
}
