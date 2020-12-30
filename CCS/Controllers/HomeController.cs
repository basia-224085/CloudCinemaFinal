
using CCS.DataRepository;
using CCS.Models;
using CCS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Azure.Storage.Blobs;

namespace CCS.Controllers
{
    public class HomeController : Controller
    {
        private Repository repo = new Repository();
        public ActionResult Index()
        {
            // Create a BlobServiceClient object which will be used to create a container client
            //BlobServiceClient blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=moviesposters;AccountKey=/W6OWyYwXeMGqpaweWBjTBKTyCrkqu+Pz4IkQJscLAz9iLxldCDZgV+OXh4YjjyL1Xn1fwHHvwl6tgER4euF3w==;BlobEndpoint=https://moviesposters.blob.core.windows.net/;TableEndpoint=https://moviesposters.table.core.windows.net/;QueueEndpoint=https://moviesposters.queue.core.windows.net/;FileEndpoint=https://moviesposters.file.core.windows.net/");

            List<Movies> movies = repo.getMoviesOfTheDay(1);
            var movieListViewModel = new MovieListViewModel(movies);
            return View(movieListViewModel);
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
            var str = "test";
            ViewBag.test = str;
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