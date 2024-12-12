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
    public class ReadBookController : ControllerBase
    {
        private readonly ReadBookController _context;

        public ReadBookController(ReadBookController context)
        {
            _context = context;
        }
        //[HttpPost("api/read-books/add")]
        /*public IActionResult AddReadBook([FromBody] ReadBook readbook)
        {
            if (!_context.Books)
        }*/
    }
}
