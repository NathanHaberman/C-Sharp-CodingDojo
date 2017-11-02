using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Portfolio.Controllers
{
    // Chaneg Example
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View("Home");
        }

        [HttpGet]
        [Route("Projects")]
        public IActionResult Projects()
        {
            return View("Project");
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}
