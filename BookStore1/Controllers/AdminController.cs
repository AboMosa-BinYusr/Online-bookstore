using BookStore1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStore1.Models;
using BookStore1.Models.Repositories.Interfaces;

namespace BookStore1.Controllers
{
    [Authorize(Policy = "HasToBeAdmin")]
    public class AdminController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IBookRepository bookRepository, IAccountRepository accountRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
            _accountRepository = accountRepository;
        }

        public IActionResult AdminMainPage()
        {
            return View();
        }
        public IActionResult ShowBooks()
        {
            var books = _bookRepository.GetBooks();
            return View(books);
        }
        public IActionResult ShowAccounts()
        {
            var accounts = _accountRepository.GetAccounts;
            return View(accounts);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                string imageName = "";
                if (book.Image != null)
                {
                    imageName = book.Image.FileName;
                    string imagesFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string imagePath = Path.Combine(imagesFolderPath, imageName);
                    book.Image.CopyTo(new FileStream(imagePath, FileMode.Create));
                }
                book.imageURL = imageName;
                _bookRepository.AddBook(book);
                return RedirectToAction("ShowBooks", "Admin");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult DeleteBook(int? id)
        {
            var book = _bookRepository.GetBook(id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult DeleteBook(Book book)
        {
            _bookRepository.DeleteBook(book);
            return RedirectToAction("ShowBooks");
        }
    }
}
