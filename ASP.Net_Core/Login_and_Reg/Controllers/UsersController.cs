using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Login_and_Reg.Models;
using Login_and_Reg;

namespace Login_and_Reg.Controllers
{
    public class UsersController : Controller
    {
        private readonly DbConnector _dbConnector;

        public UsersController(DbConnector connect){
            _dbConnector = connect;
        }
        private List<string> errors = new List<string>();

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (TempData["errors"] != null){
                ViewBag.ErrorMessages = TempData["errors"];
            }

            return View();
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user){
            if (ModelState.IsValid){
                // Add to DB, but DbConnector isnt working...
                _dbConnector.Execute($"Insert into User (firstName, lastName, email, password, created_at) Values ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}', NOW())");
                TempData["errors"] = null;
                return RedirectToAction("Success");
            } else {
                 foreach(var error in ModelState.Values){
                    if(error.Errors.Count > 0){
                        errors.Add(error.Errors[0].ErrorMessage);
                    }
                }
                TempData["errors"] = errors;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password){
            var emailExists = _dbConnector.Query($"Select * from User where email = '{email}'");
            if (emailExists.Count == 0){
                TempData["EmailError"] = "Email is not in the database";
                return RedirectToAction("Index");
            } else {
                var passwordMatch = _dbConnector.Query($"Select * from User where email = '{email}' and password = '{password}'");
                if (passwordMatch.Count == 0){
                    TempData["PasswordError"] = "Password incorrect";
                    return RedirectToAction("Index");
                } else {
                    return RedirectToAction("Success");
                }
            }
        }
    }
}
