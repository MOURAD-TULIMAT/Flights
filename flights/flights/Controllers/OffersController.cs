using flights.DTOs;
using flights.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace flights.Controllers
{
    public class OffersController : Controller
    {
        private readonly ILogger<OffersController> _logger;

        public OffersController(ILogger<OffersController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

    }
}
