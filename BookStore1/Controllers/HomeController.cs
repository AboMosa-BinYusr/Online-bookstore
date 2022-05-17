using BookStore1.Data;
using BookStore1.Models;
using BookStore1.Models.Repositories.Interfaces;
using BookStore1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BookStore1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult HomeView(int? categoryId)
        {
            IEnumerable<Category>? categories = _categoryRepository.GetCategories();
            IEnumerable<Book> books = _bookRepository.GetBooks();
            if (categoryId != null && categoryId != 0)
            {
                books = books.Where(b => b.CategoryId == categoryId);
            }
            var categoryBookViewModel = new CategoryBookViewModel
            {
                Categories = categories?.ToList(),
                Books = books.ToList(),
            };
           
            return View(categoryBookViewModel);
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