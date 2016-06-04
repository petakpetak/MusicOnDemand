using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicOnDemand.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        
        
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This site is for searching information about music and their artists.";

            return View();
        }

        [HttpPost]
        public ActionResult Edit(string query)
        {
            
            return RedirectToAction("Index", "Search", new { q = query});//#RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}