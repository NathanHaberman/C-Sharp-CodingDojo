using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// Used for Hashing
using Microsoft.AspNetCore.Identity;

// Change Namespace
using TheDojoLeague.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// Change Namespace
namespace TheDojoLeague.Controllers
{
    public class UserController : Controller
    {
        private MainContext _context;

        public UserController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/logout")]
        public IActionResult Logut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register(Wrapper regModel)
        {
            RegisterVM user = regModel.Register;

            if (ModelState.IsValid)
            {
                // Change DB Name!
                User currentUser = _context.Users.SingleOrDefault(test => test.Email == user.RegEmail);
                if (currentUser != null){
                    TempData["Email"] = "Email already been used";
                    return View("Index", regModel);
                } else {
                    PasswordHasher<RegisterVM> Hasher = new PasswordHasher<RegisterVM>();
                    User newUser = new User(){
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.RegEmail,
                        Password = Hasher.HashPassword(user,user.RegPassword),
                    };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    User activeUser = _context.Users.SingleOrDefault(test => test.Email == user.RegEmail);
                    HttpContext.Session.SetInt32("ActiveUser", activeUser.id);
                    return RedirectToAction("Home","Home");
                }
            }
            return View("Index", regModel);
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult Login(Wrapper loginModel)
        {
            if (loginModel.Login.LoginEmail == null && loginModel.Login.LoginPassword == null)
            {
                return View("Index", loginModel);
            }
            LoginVM user = loginModel.Login;

            // Change DB Name!
            User testUser = _context.Users.SingleOrDefault(test => test.Email == user.LoginEmail);
            if (testUser == null){
                TempData["LoginError"] = "Username or Password is incorrect";
                return View("Index", loginModel);
            } else {
                if (user.LoginEmail != testUser.Email){
                    TempData["LoginError"] = "Username or Password is incorrect";
                    return View("Index", loginModel);
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    if (0 == Hasher.VerifyHashedPassword(testUser, testUser.Password, user.LoginPassword)){
                        TempData["LoginError"] = "Username or Password is incorrect";
                        return View("Index", loginModel);
                    } else {
                        HttpContext.Session.SetInt32("ActiveUser", testUser.id);
                        return RedirectToAction("Home","Home");
                    }
                }
            }
        }
    }
}
