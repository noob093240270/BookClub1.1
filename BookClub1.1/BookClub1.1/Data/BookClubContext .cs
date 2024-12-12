using BookClub1._1.Models;
using Microsoft.EntityFrameworkCore;


namespace BookClub1._1.Data
{
    public class BookClubContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ReadBook> ReadBooks { get; set; }
        public BookClubContext(DbContextOptions<BookClubContext> options) : base(options) { }


    }
}
