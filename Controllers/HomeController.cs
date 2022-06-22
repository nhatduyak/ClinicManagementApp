using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClinicManagement.Controllers
{
    [Authorize]

        public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
            [TempData]
             public string StatusMessage{set;get;}

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string HiHome() => "Xin chao cac ban, toi la HiHome";
        public IActionResult Index()
        {
            return View();
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
