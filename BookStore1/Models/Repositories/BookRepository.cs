using BookStore1.Data;
using BookStore1.Models.Repositories.Interfaces;

namespace BookStore1.Models.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDataContext _database;
        public BookRepository(AppDataContext database)
        {
            _database = database;
        }
        public void AddBook(Book book)
        {
            book.CategoryId = 1;
            _database.Books.Add(book);
            _database.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            if (book != null)
            {
                _database.Books.Remove(book);
                _database.SaveChanges();
            }
        }

        public Book? GetBook(int? id)
        {
            return _database.Books.Find(id); 
        }

        public IEnumerable<Book> GetBooks()
        {
            return _database.Books; 
        }
    }
}
