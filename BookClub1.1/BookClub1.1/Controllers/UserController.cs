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
    public class UserController : ControllerBase
    {
        private readonly BookClubContext _context;

        public UserController(BookClubContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string userlogin)
        {
            var user = await _context.Users.Include(u => u.ReadBooks).FirstOrDefaultAsync(u => u.Name == userlogin);
            if (user == null)
            {
                user = new User { Name = userlogin };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            return Ok(user);
        }
    }
}
