using BookLibraryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWeb.Database
{
    public class BookLibraryDbContext: DbContext
    {
        public BookLibraryDbContext(DbContextOptions<BookLibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
