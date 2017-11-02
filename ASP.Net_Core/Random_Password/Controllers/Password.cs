using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Random_Password.Controllers
{
    public class PasswordController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count") == null){
                HttpContext.Session.SetInt32("Count",0);
            }
            int? newCount = HttpContext.Session.GetInt32("Count") + 1;
            HttpContext.Session.SetInt32("Count",(int)newCount);

            string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            string Password = "";

            Random rand = new Random();
            for (int i=0; i<15; i++){
                char character = Characters[rand.Next(0,Characters.Length)];
                Password += character;
            }

            ViewBag.Password = Password;
            ViewBag.Count = newCount;
            return View("index");
        }
    }
}
