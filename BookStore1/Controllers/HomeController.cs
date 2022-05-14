using BookStore1.Data;
using BookStore1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDataContext _database;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDataContext database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult HomeView()
        {
            IEnumerable<Book> books = _database.Books;
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}