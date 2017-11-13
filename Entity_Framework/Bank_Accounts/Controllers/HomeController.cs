using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Bank_Accounts.Models;
using System.Linq;

using Microsoft.AspNetCore.Identity;

namespace Bank_Accounts.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext _context;

        public HomeController(HomeContext context)
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
        [Route("login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpGet]
        [Route("register")]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
            int? currentId = HttpContext.Session.GetInt32("ActiveId");
            User currentUser = _context.Users.Include(user => user.Transactions).SingleOrDefault(user => user.id == (int)currentId);

            TempData["Balance"] = currentUser.Balance;
            ViewBag.Transactions = currentUser.Transactions;
            return View();
        }

        [HttpPost]
        [Route("api/addTransaction")]
        public IActionResult AddTransaction(int amount)
        {
            int id = (int)HttpContext.Session.GetInt32("ActiveId");

            Transaction newTransaction = new Transaction();
            newTransaction.Amount = amount;
            newTransaction.UserId = id;
            newTransaction.CreatedAt = DateTime.Now;

            User currentUser = _context.Users.SingleOrDefault(user => user.id == id);
            currentUser.Balance += amount;

            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register(RegisterVM user)
        {
            if (ModelState.IsValid)
            {
                User currentUser = _context.Users.SingleOrDefault(test => test.Email == user.Email);
                if (currentUser != null){
                    TempData["Email"] = "Email already been used";
                    return View("RegisterPage", user);
                } else {
                    PasswordHasher<RegisterVM> Hasher = new PasswordHasher<RegisterVM>();
                    User newUser = new User(){
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = Hasher.HashPassword(user,user.Password),
                    };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    User activeUser = _context.Users.SingleOrDefault(test => test.Email == user.Email);
                    HttpContext.Session.SetInt32("ActiveId", activeUser.id);
                    return RedirectToAction("Home");
                }
            }
            return View("RegisterPage", user);
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult Login(LoginVM user)
        {
            User testUser = _context.Users.SingleOrDefault(test => test.Email == user.Email);
            if (testUser == null){
                TempData["Error"] = "Username or Password is incorrect";
                return View("LoginPage", user);
            } else {
                if (user.Email != testUser.Email){
                    TempData["Error"] = "Username or Password is incorrect";
                    return View("LoginPage", user);
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    if (0 == Hasher.VerifyHashedPassword(testUser, testUser.Password, user.Password)){
                        TempData["Error"] = "Username or Password is incorrect";
                        return View("LoginPage", user);
                    } else {
                        HttpContext.Session.SetInt32("ActiveId", testUser.id);
                        return RedirectToAction("Home");
                    }
                }
            }
        }
    }
}
