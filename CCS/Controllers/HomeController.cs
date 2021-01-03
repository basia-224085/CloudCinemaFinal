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

        CloudBlockBlob GetBlobInContainer(string container, string fileName)
        {
            //use web.config appSetting to get connection setting .NET Framework's ConfigurationManager class can also be used for this
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol = https; AccountName = moviesposters; AccountKey =/ W6OWyYwXeMGqpaweWBjTBKTyCrkqu + Pz4IkQJscLAz9iLxldCDZgV + OXh4YjjyL1Xn1fwHHvwl6tgER4euF3w ==; EndpointSuffix = core.windows.net");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["my_connection"].ConnectionString);
            //create the blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            //retrieve a refernce to a container
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(container);
            //set permission to show to public
            blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            blobContainer.CreateIfNotExists();
            // Retrieve reference to a blob named "photo1.jpg".
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(fileName);
            return blockBlob;
        }
        public ActionResult Index()
        {
            CloudBlockBlob blob = GetBlobInContainer("posters", "id11.jpg");
            string uri_blob = blob.Uri.AbsoluteUri;
            ViewBag.uri_blob = uri_blob;
            string user_id = User.Identity.GetUserId();
            ViewBag.user_id = user_id;
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

     /*   [HttpPost]
        [WebMethod]
        public ActionResult TicketsResult(string JsonLocalStorageObj)
        {
            ReturnedTickets returned_tickets = JsonConvert.DeserializeObject<ReturnedTickets>(JsonLocalStorageObj);
            return Content("Success");
        }*/

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
            ReturnedReservation returned_reservation = JsonConvert.DeserializeObject<ReturnedReservation>(JsonLocalStorageObj);
            repo.updateReservedSpots(returned_reservation.Returned_schedule_id, returned_reservation.Returned_reserved_spots);
            repo.addReservation(returned_reservation.Returned_schedule_id, User.Identity.GetUserId());
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