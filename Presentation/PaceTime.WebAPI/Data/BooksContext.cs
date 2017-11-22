using PaceTime.Domain.Models;
using System.Data.Entity;


namespace PaceTime.WebAPI.Data
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public BooksContext()
            : base("BooksContext")
        {
        }
    }
}