using BookStore1.Models;

namespace BookStore1.ViewModels
{
    public class AddBookViewModel
    {
        public IEnumerable<Category>? Categories { get; set; }
        public Book? Book { get; set; }


    }
}
