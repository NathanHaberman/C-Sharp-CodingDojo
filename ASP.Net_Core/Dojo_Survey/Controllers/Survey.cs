using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Survey.Controllers
{
    public class SurveyController : Controller
    {
        private string CurrentName = "";
        private string CurrentCity = "";
        private string CurrentComments = "";

        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View("Survey");
        }

        [HttpGet]
        [Route("submitted")]
        public IActionResult Submitted()
        {
            ViewBag.Name = CurrentName;
            ViewBag.City = CurrentCity;
            ViewBag.Comments = CurrentComments;
            return View("Submit");
        }

        [HttpPost]
        [Route("post/survey")]
        public IActionResult Survey(string Name, string City, string Comments){
            CurrentName = Name;
            CurrentCity = City;
            CurrentComments = Comments;

            return Submitted();
        }
    }
}