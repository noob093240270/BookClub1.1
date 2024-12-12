using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookClub1._1.Data;
using BookClub1._1.Models;
using BCrypt.Net;

namespace BookClub1._1.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly BookClubContext _context;

        public UserController(BookClubContext context)
        {
            _context = context;
        }

        [HttpPost("api/users/register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if (_context.Users.Any(u => u.Name == user.Name))
            {
                return BadRequest("Пользователь с таким именем уже существует");
            }

            var user1 = new User
            {
                Name = user.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };

            _context.Users.Add(user1);
            _context.SaveChanges();
            return Ok("Пользователь зарегистрирован");
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] User name )
        {
            var user =  _context.Users.FirstOrDefault(u => u.Name == name.Name);
            if (user == null || !BCrypt.Net.BCrypt.Verify(name.Password, user.Password))
            {
                return Unauthorized("Неверный логин или пароль");
            }
            return Ok(new { userId = user.Id, userLogin = user.Name });
        }
    }
}
