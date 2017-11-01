using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Calling_Card.Controllers
{
    public class TimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }
    }
}
