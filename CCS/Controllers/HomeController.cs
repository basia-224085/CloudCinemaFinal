
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
        public ActionResult Index()
        {
            Movie movie = new Movie("My movie title", "action", 22, 232);
            Movie movie2 = new Movie("My movie title2", "action", 22, 232);
            Movie movie3 = new Movie("My movie title3", "action", 22, 232);
            Movie movie4 = new Movie("My movie title4", "action", 22, 232);
            movie.Description = "tralalalalla";
            movie2.Description = "tralalalalla222222";
            List<Movie> movies = new List<Movie>();
            movies.Add(movie);
            movies.Add(movie2);
            movies.Add(movie3);
            movies.Add(movie4);
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