using flights.Data;
using flights.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flights.Controllers
{
    public class OffersController : Controller
    {
        private readonly ILogger<OffersController> _logger;
        private readonly ApplicationDbContext _context;
        private IHttpContextAccessor _accessor;

        public OffersController(
            IHttpContextAccessor accessor,
            ILogger<OffersController> logger,
            ApplicationDbContext context)
        {
            _accessor = accessor;
            _logger = logger;
            _context = context;
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                string email = _accessor.HttpContext.Request.Cookies["currentUser"];
                if (!string.IsNullOrEmpty(email))
                {
                    var account = await _context.
                        Accounts.FirstAsync(a => a.UserName == email);

                    TempData["currentUser"] = account.UserName;

                    var adminTyoe = await _context
                        .AccountTypes.FirstAsync(a => a.Name == "Admin");

                    var userType = UserType.User;

                    if (account.TypeId == adminTyoe.Id)
                        userType = UserType.Admin;

                    TempData["currentUserType"] = userType.ToString();
                }

                var all = await GetAllOffersAsync();

                return View(all);
            }
            catch (Exception)
            {
                return RedirectToAction("", "Error");
            }
        }

        private async Task<AllInfoDto> GetAllOffersAsync()
        {
            var result = new AllInfoDto
            {
                Flights = new List<FlightDto>()
            };

            var allOffers = await _context
                .Flights.Where(f => f.Status == (byte)FlightStatus.Offer)
                .ToListAsync();

            foreach(var offer in allOffers)
            {
                var airportFrom = await _context
                    .Airports.FirstAsync(a => a.Id == offer.AirportFromId);

                var airportTo = await _context
                    .Airports.FirstAsync(a => a.Id == offer.AirportToId);

                var airplane = await _context
                    .Airplanes.FirstAsync(a => a.Id == offer.AirplaneId);

                var flight = new FlightDto
                {
                    FlightId = offer.Id,
                    FromAirport = airportFrom.Name,
                    ToAirport = airportTo.Name,
                    Airplane = airplane.Name,
                    ArrivalTime = offer.ArrivalTime,
                    DepartureTime = offer.DepartureTime,
                    Date = offer.Date,
                    BusinessTicketPrice = offer.BusinessTicketPrice,
                    TicketPrice = offer.TicketPrice,
                    ChildTicketPrice = offer.ChildTicketPrice,
                    EconominyTicketPrice = offer.EconominTicketPrice
                };

                result.Flights.Add(flight);
            }

            string email = _accessor.HttpContext.Request.Cookies["currentUser"];
            if (!string.IsNullOrEmpty(email))
            {
                var account = await _context.
                    Accounts.FirstAsync(a => a.UserName == email);

                var user = await _context
                    .Users.FirstAsync(a => a.AccountId == account.Id);

                var fullName = user.Name.Split(' ');

                result.User = new UserDto
                {
                    Fname = fullName[0],
                    Lname = fullName[1]
                };
            }

            return result;
        }

        [HttpPost]
        public IActionResult Book(AllInfoDto allInfo)
        {
            try
            {
                return RedirectToAction("", "Offers");
            }
            catch (Exception)
            {
                return RedirectToAction("", "Error");
            }
        }

        public IActionResult Logout()
        {
            try
            {
                Response.Cookies.Delete("currentUser");
                TempData.Remove("currentUser");
                return RedirectToAction("", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("", "Error");
            }
        }


    }
}
