using CCS.DataRepository;
using CCS.Models;
using CCS.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;

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
        [HttpPost]
        [WebMethod]
        public ActionResult TicketsResult(string JsonLocalStorageObj)
        {
            ReturnedTickets returned_tickets = JsonConvert.DeserializeObject<ReturnedTickets>(JsonLocalStorageObj);
            repo.updateReservedSpots(returned_tickets.Returned_schedule_id, returned_tickets.Returned_reserved_spots);
            return Content("Success");
        }

        public ActionResult Seats()
        {

            return View();
        }
        public ActionResult Reservation()
        {
            return View();
        }

        [HttpPost]
        [WebMethod]
        public ActionResult ReservationResult(string JsonLocalStorageObj)
        {
            ReturnedReservation returned_reservation = JsonConvert.DeserializeObject<ReturnedReservation>(JsonLocalStorageObj);
            repo.addReservation(returned_reservation.Returned_schedule_id, returned_reservation.Returned_user_email);
            return Content("Succes");
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