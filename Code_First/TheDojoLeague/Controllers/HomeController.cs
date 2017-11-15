using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// Change Namespace
using TheDojoLeague.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// Change Namespace
namespace TheDojoLeague.Controllers
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
            User user = _context.Users.Include(i => i.Ninjas).Include(i => i.Dojos).SingleOrDefault(i => i.id == (int)HttpContext.Session.GetInt32("ActiveUser"));
            ViewBag.User = user;
            return View();
        }

        [HttpGet]
        [Route("NewNinja")]
        public IActionResult NewNinja()
        {
            return View();
        }

        [HttpGet]
        [Route("NewDojo")]
        public IActionResult NewDojo()
        {
            return View();
        }

        [HttpPost]
        [Route("api/create/ninja")]
        public IActionResult CreateNinja(Ninja ninja)
        {
            if(ModelState.IsValid)
            {
                ninja.UserId = (int)HttpContext.Session.GetInt32("ActiveUser");
                _context.Ninjas.Add(ninja);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            return View("NewNinja", ninja);
        }

        [HttpPost]
        [Route("api/create/dojo")]
        public IActionResult CreateDojo(Dojo dojo)
        {
            if(ModelState.IsValid)
            {
                dojo.UserId = (int)HttpContext.Session.GetInt32("ActiveUser");
                _context.Dojos.Add(dojo);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            return View("NewDojo", dojo);
        }
    }
}
