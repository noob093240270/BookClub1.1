using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookClub1._1.Data;
using BookClub1._1.Models;

namespace BookClub1._1.Controllers
{
    public class BookController : Controller
    {
        private readonly BookClubContext _context;

        public BookController(BookClubContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks() => Ok(await _context.Books.ToListAsync());

        [HttpGet("user-books/{Id}")]
        public async Task<IActionResult> GetUserBooks(int id)
        {
            var user = await _context.Users.Include(u => u.ReadBooks).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ReadBooks);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBookForUser(int userId, int bookId)
        {
            var user = await _context.Users.Include(u => u.ReadBooks).FirstOrDefaultAsync(u => userId == u.Id);
            var book = await _context.Books.FindAsync(bookId);
            if (user == null || book == null)
            {
                return NotFound();
            }

            user.ReadBooks.Add(book);
            await _context.SaveChangesAsync();
            return Ok();

        }


        [HttpPost("delete")]
        public async Task<IActionResult> DeleteBookFromUser(int userId, int bookId)
        {
            var user = await _context.Users.Include(u => u.ReadBooks).FirstOrDefaultAsync(u => userId == u.Id);
            var book = user.ReadBooks.FirstOrDefault(u => user.Id == bookId);
            if (book == null || user == null)
            {
                return NotFound();
            }
            user.ReadBooks.Remove(book);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
