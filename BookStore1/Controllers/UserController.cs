using BookStore1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookStore1.ViewModels;
using BookStore1.Models.Comments;
using Microsoft.EntityFrameworkCore;
using BookStore1.Models.Repositories.Interfaces;

namespace BookStore1.Controllers
{
    public class UserController : Controller
    {
        private readonly IMainCommentRepository _mainCommentRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ISubCommentRepository _subCommentRepository;

        public UserController(IMainCommentRepository mainCommentRepository, IBookRepository bookRepository, 
               ISubCommentRepository subCommentRepository)
        {
            _mainCommentRepository = mainCommentRepository;
            _bookRepository = bookRepository;
            _subCommentRepository = subCommentRepository;
        }
        public IActionResult ViewBook(int? id)
        {
            var book = _bookRepository.GetBook(id);
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
                _mainCommentRepository.AddMainComment(commentViewModel, User.Identity.Name);
            }
            else
            {
                _subCommentRepository.AddSubComment(commentViewModel, User.Identity.Name);
            }
            return RedirectToAction("ViewBook", new { id = commentViewModel?.Book?.Id });
        }
    }
}
