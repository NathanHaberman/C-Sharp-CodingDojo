using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers
{
    public class ReviewController : Controller
    {

        private RESTauranterContext _context;

        public ReviewController(RESTauranterContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult AllReviews()
        {
            IEnumerable<Review> returnedReviews = _context.Review.ToList();
            TempData["AllReviews"] = returnedReviews;
            return View();
        }

        [HttpPost]
        [Route("api/addReview")]
        public IActionResult NewReview(Review review)
        {
            if (ModelState.IsValid)
            {
                if (review.visitDate > DateTime.Now)
                {
                    TempData["DateError"] = "Date must be in the past";
                    return View("Index", review);
                }
                else
                {
                    // Add to DB
                    _context.Add(review);
                    _context.SaveChanges();
                    return RedirectToAction("AllReviews");
                }
            }
            else
            {
                if (review.visitDate > DateTime.Now)
                {
                    TempData["DateError"] = "Date must be in the past";
                    return View("Index", review);
                }
                return View("Index", review);
            }
        }
    }
}
