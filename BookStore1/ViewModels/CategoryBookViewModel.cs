using BookStore1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore1.ViewModels
{
    public class CategoryBookViewModel
    {
        public List<Book>? Books { get; set; }
        public List<Category>? Categories { get; set; }
        public int CategoryId { get; set; }
        public string? SearchText { get; set; }
    }
}
