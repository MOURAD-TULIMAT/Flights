using flights.DTOs;
using flights.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace flights.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Offers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDto userDto)
        {
            return RedirectToAction("", "Home");
        }

        [HttpPost]
        public IActionResult Signup(UserDto userDto)
        {
            return RedirectToAction("", "Home");
        }

        [HttpPost]
        public IActionResult Close(UserDto userDto)
        {
            return RedirectToAction("", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
