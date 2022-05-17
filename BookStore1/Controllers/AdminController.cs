using BookStore1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStore1.Models;
using BookStore1.Models.Repositories.Interfaces;
using BookStore1.ViewModels;

namespace BookStore1.Controllers
{
    [Authorize(Policy = "HasToBeAdmin")]
    public class AdminController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IBookRepository bookRepository, IAccountRepository accountRepository,
            IWebHostEnvironment webHostEnvironment, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
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
        [HttpGet]
        public IActionResult AddBook()
        {
            var addBookViewModel = new AddBookViewModel
            {
                Categories = _categoryRepository.GetCategories()
            };
            return View(addBookViewModel);
        }
        public IActionResult AddBook(AddBookViewModel addBookViewModel)
        {
            var book = addBookViewModel.Book;
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
            return View(addBookViewModel);
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
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
            return RedirectToAction("AdminMainPage");
        }
    }
}
