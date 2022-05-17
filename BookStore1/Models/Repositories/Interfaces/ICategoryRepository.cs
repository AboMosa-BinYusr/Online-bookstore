namespace BookStore1.Models.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        IEnumerable<Category>? GetCategories(); 
    }
}
