using CCS.DataRepository;
using CCS.Models;
using CCS.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CCS.Controllers
{
    public class HomeController : Controller
    {
        private Repository repo = new Repository();
        public ActionResult Index()
        {
            List<Show> shows = repo.getShows();
            var homeViewModel = new HomeViewModel(shows);
            return View(homeViewModel);
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