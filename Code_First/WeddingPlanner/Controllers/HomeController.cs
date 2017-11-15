using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MainContext _context;

        public HomeController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            ViewBag.Weddings = _context.Weddings.Include(i => i.Guests).Where(i => i.id > 0).ToList();
            ViewBag.ActiveUser = (int)HttpContext.Session.GetInt32("ActiveUser");
            return View();
        }

        [HttpGet]
        [Route("AddWedding")]
        public IActionResult AddWedding()
        {
            return View();
        }

        [HttpPost]
        [Route("api/create/wedding")]
        public IActionResult CreateWedding(WeddingVM wedding)
        {
            if(ModelState.IsValid)
            {
                if(wedding.Date < DateTime.Now){
                    TempData["DateError"] = "Date must be in the future";
                    return View("AddWedding", wedding);
                } else {
                    Wedding newWedding = new Wedding();
                    newWedding.Wedder1 = wedding.Wedder1;
                    newWedding.Wedder2 = wedding.Wedder2;
                    newWedding.Date = wedding.Date;
                    newWedding.Address = wedding.Address;
                    newWedding.OwnerId = (int)HttpContext.Session.GetInt32("ActiveUser");

                    _context.Weddings.Add(newWedding);
                    _context.SaveChanges();

                    return RedirectToAction("WeddingPage", new { id = newWedding.id });
                }
            }
            return View("AddWedding", wedding);
        }

        [HttpGet]
        [Route("WeddingPage/{id}")]
        public IActionResult WeddingPage(int id)
        {
            Wedding wedding = _context.Weddings.Include(i => i.Guests).ThenInclude(i => i.User).SingleOrDefault(item => item.id == id);

            TempData["Name"] = $"Wedding of {wedding.Wedder1} & {wedding.Wedder2}";
            ViewBag.Wedding = wedding;
            return View();
        }

        [HttpPost]
        [Route("api/delete/wedding/{id}")]
        public IActionResult DeleteWedding(int id)
        {
            Wedding wedding = _context.Weddings.SingleOrDefault(i => i.id == id);
            _context.Weddings.Remove(wedding);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpPost]
        [Route("api/RSVP/wedding/{id}")]
        public IActionResult RSVP(int id)
        {
            Guest guest = new Guest();
            guest.UserId = (int)HttpContext.Session.GetInt32("ActiveUser");
            guest.WeddingId = id;
            _context.Guests.Add(guest);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpPost]
        [Route("")]
        public IActionResult UnRSVP(int id)
        {
            Guest guest = _context.Guests.SingleOrDefault(i => i.id == id);
            _context.Guests.Remove(guest);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
    }
}
