using flights.Data;
using flights.DTOs;
using flights.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace flights.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
        public async Task<IActionResult> LoginAsync(UserDto userDto)
        {
            try
            {
                var account = await _context
                    .Accounts.FirstOrDefaultAsync(a => a.UserName == userDto.Email);
                
                if (account == null)
                {
                    TempData["login"] = "false";
                    return RedirectToAction("", "Home");
                }

                if(account.Password != userDto.Password)
                {
                    TempData["login"] = "false";
                    return RedirectToAction("", "Home");
                }

                var userTyoe = await _context
                    .AccountTypes.FirstAsync(a => a.Name == "User");

                var adminTyoe = await _context
                    .AccountTypes.FirstAsync(a => a.Name == "Admin");



                return RedirectToAction("", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignupAsync(UserDto userDto)
        {
            try
            {
                var accountTyoe = await _context
                    .AccountTypes.FirstAsync(a => a.Name == "User");

                var account = new Account
                {
                    Id = Guid.NewGuid(),
                    UserName = userDto.Email,
                    Password = userDto.Password,
                    TypeId = accountTyoe.Id,
                    CreationDate = DateTime.Now.ToShortDateString()
                };

                await _context.Accounts.AddAsync(account);

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    AccountId = account.Id,
                    Name = $"{userDto.Fname} {userDto.Lname}",
                    Address = "",
                    Phone = "",
                };

                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();

                return RedirectToAction("", "Home");
            }
            catch(Exception)
            {
                return RedirectToAction("", "Error");
            }
        }

        [HttpPost]
        public IActionResult Close(UserDto userDto)
        {
            return RedirectToAction("", "Home");
        }
    }
}
