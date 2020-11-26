using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCinemaFinal.Controllers
{
    public class SeatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
