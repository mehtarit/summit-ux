using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Summit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Region,string Program)
        {
            ViewBag.Title = "Home Page";
            ViewBag.Region = Region;
            ViewBag.Program = Program;

            return View();
        }
    }
}
