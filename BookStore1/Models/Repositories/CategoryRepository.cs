using BookStore1.Data;
using BookStore1.Models.Repositories.Interfaces;

namespace BookStore1.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDataContext _database;

        public CategoryRepository(AppDataContext database)
        {
            _database = database;
        }

        public void AddCategory(Category category)
        {
            _database.Categories.Add(category);
        }

        public IEnumerable<Category>? GetCategories()
        {
            return _database.Categories;
        }
    }
}
