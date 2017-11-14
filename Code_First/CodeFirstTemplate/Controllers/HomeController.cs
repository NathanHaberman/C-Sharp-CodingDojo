using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// Change Namespace
using CodeFirstTemplate.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// Change Namespace
namespace CodeFirstTemplate.Controllers
{
    public class HomeController : Controller
    {
        private MainContext _context;

        public HomeController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
            return View();
        }
    }
}
