using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Form_Submission.Models;

namespace Form_Submission.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/submit")]
        public IActionResult Submit(string firstName, string lastName, int age, string email, string password)
        {
            User NewUser = new User();
            NewUser.FirstName = firstName;
            NewUser.LastName = lastName;
            NewUser.Age = age;
            NewUser.Email = email;
            NewUser.Password = password;

            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;

            return View();

        }
    }
}
