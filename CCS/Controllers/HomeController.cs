using CCS.DataRepository;
using CCS.Models;
using CCS.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using System.Configuration;

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
            string user_id = User.Identity.GetUserId();
            ViewBag.user_id = repo.getEmailByUserId(user_id);
            return View();
        }

        [HttpPost]
        [WebMethod]
        public ActionResult ReservationResult(string JsonLocalStorageObj)
        {
            ReturnedReservation returned_reservation = 
                JsonConvert.DeserializeObject<ReturnedReservation>(JsonLocalStorageObj);
            
            repo.updateReservedSpots(returned_reservation.Returned_schedule_id,
                returned_reservation.Returned_reserved_spots);
            repo.addReservation(returned_reservation.Returned_schedule_id,
                User.Identity.GetUserId());
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

        public ActionResult ReservationRecords()
        {
            string user_id = User.Identity.GetUserId();
            List<ReservationRecord> records = repo.getReservations(user_id);
            MyReservationsViewModel reservationsViewModel = new MyReservationsViewModel(records);
            return View(reservationsViewModel);
        }
    }
}