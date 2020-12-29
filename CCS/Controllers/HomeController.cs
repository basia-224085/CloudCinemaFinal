
using CCS.DataRepository;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Controllers
{
    public class HomeController : Controller
    {
        private Repository repo = new Repository();
        public ActionResult Index()
        {
            List<Movies> movies = repo.getMoviesOfTheDay(1);
            ViewBag.movies = movies;
            return View();
        }
        public ActionResult Trailer()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Tickets()
        {
            int tickets = 0;
            ViewBag.tickets = tickets;
            return View();
        }
        public ActionResult Seats()
        {
            return View();
        }
        public ActionResult Reservation()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}