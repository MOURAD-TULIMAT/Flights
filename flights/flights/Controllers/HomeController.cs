using flights.Data;
using flights.DTOs;
using flights.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace flights.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private IHttpContextAccessor _accessor;

        public HomeController(
            IHttpContextAccessor accessor,
            ILogger<HomeController> logger,
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

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("", "Error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(AllInfoDto allInfo)
        {
            try
            {
                var userDto = allInfo.User;

                var account = await _context
                    .Accounts.FirstOrDefaultAsync(a => a.UserName == userDto.Email);

                if (account == null)
                {
                    TempData["login"] = "false";
                    return RedirectToAction("", "Home");
                }

                if (account.Password != userDto.Password)
                {
                    TempData["login"] = "false";
                    return RedirectToAction("", "Home");
                }


                var adminTyoe = await _context
                    .AccountTypes.FirstAsync(a => a.Name == "Admin");

                var userType = UserType.User;

                if (account.TypeId == adminTyoe.Id)
                    userType = UserType.Admin;

                CookieOptions option = new()
                {
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("currentUser", account.UserName, option);

                ViewBag.credentials = true;
                TempData["currentUser"] = account.UserName;
                TempData["currentUserType"] = userType.ToString();

                return RedirectToAction("", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignupAsync(AllInfoDto allInfo)
        {
            try
            {
                var userDto = allInfo.User;

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
            catch (Exception)
            {
                return RedirectToAction("", "Error");
            }
        }

        [HttpPost]
        public IActionResult Search()
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
