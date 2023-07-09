using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Education
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Home ";

            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            ViewBag.Title = "Home | AboutUs";
            return View();
        }

        [HttpGet]
        //[Route("/ContactUs", Name = "SiteInfo")]
        public IActionResult ContactUs()
        {
            ViewBag.Title = "Home | ContactUs";
            return View();
        }
    }
}


