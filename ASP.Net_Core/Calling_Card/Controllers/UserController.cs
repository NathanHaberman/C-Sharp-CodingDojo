using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Calling_Card.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult Index(string FirstName, string LastName, string Age, string FavColor)
        {
            var output = new {
                firstName = FirstName,
                lastName = LastName,
                age = Age,
                favColor = FavColor
            };
            return Json(output);
        }
        public JsonResult Default(){
            var output = new {
                enterRouteLike = "FirstName/LastName/Age/FavoriteColor"
            };
            return Json(output);
        }
    }
}
