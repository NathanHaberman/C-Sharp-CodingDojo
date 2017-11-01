using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
// Change Example to your namespace
namespace Example.Controllers
{
    // Chaneg Example
    public class ExampleController : Controller
    {
        [HttpGet] // HttpGet or HttpPost
        [Route("")] // Add Route here
        public JsonResult Example()
        {
            var output = new {
                Example = "Example"
            };
            return Json(output);
        }
    }
}
