using BookStore1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStore1.Models;

namespace BookStore1.Controllers
{
    [Authorize(Policy = "HasToBeAdmin")]
    public class AdminController : Controller
    {
        private readonly AppDataContext _database;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(AppDataContext database, IWebHostEnvironment webHostEnvironment)
        {
            _database = database;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult AdminMainPage()
        {
            return View();
        }
        public IActionResult ShowBooks()
        {
            var books = _database.Books.ToList();
            return View(books);
        }
        public IActionResult ShowAccounts()
        {
            var accounts = _database.Accounts.ToList();
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
                _database.Books.Add(book);
                _database.SaveChanges();
                return RedirectToAction("ShowBooks", "Admin");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult DeleteBook(int? id)
        {
            var book = _database.Books.Find(id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult DeleteBook(Book book)
        {
            _database.Books.Remove(book);
            _database.SaveChanges();
            return RedirectToAction("ShowBooks");
        }
    }
}
