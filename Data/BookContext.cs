using BM_INFOTRADE_ASP.NETCORE_6.Models;
using Microsoft.EntityFrameworkCore;

namespace BM_INFOTRADE_ASP.NETCORE_6.Data
{
    public class BookContext :DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) :base (options) { }
        public DbSet<Book> Books { get; set; }
    }
}
