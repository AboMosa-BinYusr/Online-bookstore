using BookStore1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookStore1.ViewModels;
using BookStore1.Models.Comments;
using Microsoft.EntityFrameworkCore;

namespace BookStore1.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataContext _database;
        public UserController(AppDataContext database)
        {
            _database = database;
        }
        public IActionResult ViewBook(int? id)
        {
            var book = _database.Books
                .Include(b => b.MainComments)
                .ThenInclude(mainComment => mainComment.SubComments)
                .FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(new BookCommentViewModel { Book = book,});
        }
        [HttpPost]
        [Authorize("HasToBeSignedIn")]
        public IActionResult Comment(BookCommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ViewBook", new {id = commentViewModel?.Book?.Id});
            }
            if (commentViewModel.CommentIntialId == 0)
            {
                _database.MainComments.Add(new MainComment
                {
                    CommentText = commentViewModel.CommentText,
                    BookId = commentViewModel.Book.Id,
                    UserName = User.Identity.Name,
                    CreationDate = DateTime.Now,
                });
                _database.SaveChanges();
            }
            else
            {
                var comment = new SubComment();
                //{
                //    MainCommentId = commentViewModel.CommentId,
                //    CommentText = commentViewModel.CommentText,
                //    CreationDate = DateTime.Now,
                //};
            }
            return RedirectToAction("ViewBook", new { id = commentViewModel?.Book?.Id });
        }
    }
}
