using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
 
namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("fullness") == null){
                HttpContext.Session.SetString("alive","alive");
                HttpContext.Session.SetInt32("fullness",20);
                HttpContext.Session.SetInt32("happiness",20);
                HttpContext.Session.SetInt32("energy",20);
                HttpContext.Session.SetInt32("meals",3);
            }

            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            ViewBag.meals = HttpContext.Session.GetInt32("meals");

            if(ViewBag.fullness < 1 || ViewBag.happiness < 1 || ViewBag.energy < 1){
                ViewBag.fullness = 0;
                ViewBag.happiness = 0;
                ViewBag.energy = 0;
                HttpContext.Session.SetString("alive", "dead");
                HttpContext.Session.SetString("message","Your Dojodachi is dead...");
            }

            if(ViewBag.fullness >= 100 && ViewBag.happiness >= 100 && ViewBag.energy >= 100){
                HttpContext.Session.SetString("alive", "win");
                HttpContext.Session.SetString("message","Congrats you win!!");
            }

            ViewBag.alive = HttpContext.Session.GetString("alive");
            ViewBag.message = HttpContext.Session.GetString("message");

            return View("index");
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult Feed(){
            if(HttpContext.Session.GetInt32("meals") > 0){
                int? newMeals = HttpContext.Session.GetInt32("meals") - 1;
                Random rand = new Random();
                int like = rand.Next(1,5);
                if (like == 1){
                    HttpContext.Session.SetString("message",$"Your Dojodachi didn't like that");
                } else {
                    int fill = rand.Next(5,11);

                    int? newFullness = HttpContext.Session.GetInt32("fullness") + fill;

                    HttpContext.Session.SetInt32("fullness",(int)newFullness);

                    HttpContext.Session.SetString("message",$"Your Dojodachi's fullness increased by {fill} from feeding");
                }
                HttpContext.Session.SetInt32("meals",(int)newMeals);
            } else {
                HttpContext.Session.SetString("message",$"Your Dojodachi has no more meals left, work to get more!");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("play")]
        public IActionResult Play(){
            Random rand = new Random();
            int? newEnergy = HttpContext.Session.GetInt32("energy") - 5;

            int like = rand.Next(1,5);
            if(like == 1){
                HttpContext.Session.SetString("message",$"Your Dojodachi didn't like that!!");
            } else {
                int happy = rand.Next(5,11);

                int? newHappiness = HttpContext.Session.GetInt32("happiness") + happy;

                HttpContext.Session.SetInt32("happiness",(int)newHappiness);

                HttpContext.Session.SetString("message",$"Your Dojodachi's happiness increased by {happy} from playing");
            }

            HttpContext.Session.SetInt32("energy",(int)newEnergy);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("work")]
        public IActionResult Work(){
            Random rand = new Random();
            int? newEnergy = HttpContext.Session.GetInt32("energy") - 5;
            int? newMeals = HttpContext.Session.GetInt32("meals") + rand.Next(1,4);

            HttpContext.Session.SetInt32("energy", (int)newEnergy);
            HttpContext.Session.SetInt32("meals", (int)newMeals);

            HttpContext.Session.SetString("message",$"Your Dojodachi now has {newMeals} from working");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep(){
            int? newEnergy = HttpContext.Session.GetInt32("energy") + 15;
            int? newFullness = HttpContext.Session.GetInt32("fullness") - 5;
            int? newHappiness = HttpContext.Session.GetInt32("happiness") - 5;

            HttpContext.Session.SetInt32("energy",(int)newEnergy);
            HttpContext.Session.SetInt32("fullness",(int)newFullness);
            HttpContext.Session.SetInt32("happiness",(int)newHappiness);

            HttpContext.Session.SetString("message","Your Dojodachi got nice and rested");

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset(){
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}