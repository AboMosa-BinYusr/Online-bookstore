using BookStore1.Data;
using BookStore1.Models.Comments;
using BookStore1.Models.Repositories.Interfaces;
using BookStore1.ViewModels;

namespace BookStore1.Models.Repositories
{
    public class SubCommentRepository : ISubCommentRepository
    {
        private readonly AppDataContext _database;

        public SubCommentRepository(AppDataContext database)
        {
            _database = database;
        }

        public void AddSubComment(BookCommentViewModel bookCommentViewModel, string? userName)
        {
            _database.SubComments.Add(new SubComment
            {
                MainCommentId = bookCommentViewModel.CommentIntialId,
                CommentText = bookCommentViewModel.CommentText,
                UserName = userName,
                CreationDate = DateTime.Now,
            });
            _database.SaveChanges();
        }
    }
}
