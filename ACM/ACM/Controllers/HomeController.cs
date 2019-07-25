using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACM.Models;
using ACM.Services;

namespace ACM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBillService billService;

        public HomeController(IBillService billService)
        {
            this.billService = billService;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(billService.GetWallOfShameList());
            }
            return View("UnauthenticatedUserIndex");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
