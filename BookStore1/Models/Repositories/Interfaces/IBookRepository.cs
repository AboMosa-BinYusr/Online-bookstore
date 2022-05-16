namespace BookStore1.Models.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Book? GetBook(int? id);
        IEnumerable<Book> GetBooks();
        void AddBook(Book book);
        void DeleteBook(Book book);

    }
}
