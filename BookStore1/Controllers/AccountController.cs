using Microsoft.AspNetCore.Mvc;
using BookStore1.Data;
using BookStore1.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace BookStore1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDataContext _database;
        public const string COOKIE = "CookieAuth";
        public AccountController(AppDataContext database)
        {
            _database = database;
        }
        [HttpGet]
        public IActionResult Reigester()
        {
            return View();
        }
        public IActionResult Reigster(Account account)
        {
            if (ModelState.IsValid)
            {
                _database.Accounts.Add(account);
                _database.SaveChanges();
                return RedirectToAction("Success");
            }
            return View(account);
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            var _account = _database.Accounts.Where(
                acc => acc.UserName == UserName && acc.Password == Password
                ).FirstOrDefault();
            if (_account != null)
            {
                List<Claim> claims = new()
                {
                    new Claim("AccountType", _account.AccountType),
                    new Claim(ClaimTypes.Name, _account.UserName),
                };
                ClaimsIdentity identity = new(claims, COOKIE);
                ClaimsPrincipal claimPricipal = new(identity);
                await HttpContext.SignInAsync(COOKIE, claimPricipal);
                if (_account.AccountType == "Admin")
                {
                    return RedirectToAction("AdminMainPage", "Admin");
                }
                return RedirectToAction("HomeView", "Home");
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(COOKIE);
            return RedirectToAction("HomeView", "Home");
        }
    }
}
