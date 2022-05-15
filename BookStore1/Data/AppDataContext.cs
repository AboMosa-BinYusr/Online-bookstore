using Microsoft.EntityFrameworkCore;
using BookStore1.Models;
using BookStore1.Models.Comments;

namespace BookStore1.Data
{
    public class AppDataContext: DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
